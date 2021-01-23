    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    namespace BKForensics.Workbench.InstallerPermissions {
        [RunInstaller(true)]
        public partial class ServiceInstaller : System.Configuration.Install.Installer {
            // This will be the path that all of the DLLs will be located in under Program Files.
            // In the File System of the Installer Project, this is the "Application Folder"
            // The Properties have the Default Location set to [ProgramFilesFolder][Manufacturer]\[ProductName]
            private const string InstallationPath = @"C:\Program Files\Installation";
            // This is the list I had of all the DLLs and OCX files I needed to install for easy reference.
            private const string OCX = "something.ocx";
            private const string Excel = "Interop.Excel.dll";
            private const string Word = "Interop.Word.dll";
            private const string Office = "Interop.Microsoft.Office.Core.dll";
            public override void Install(System.Collections.IDictionary stateSaver) {
                base.Install(stateSaver);
    
                // OCX needs to run with regsvr, so false for the 2nd param.
                RunRegistration(OCX, false, true);
                // The Interops need regasm.
                RunRegistration(Office, true, true);
                RunRegistration(Word, true, true);
                RunRegistration(Excel, true, true);
            }
            public override void Uninstall(System.Collections.IDictionary savedState) {
                base.Uninstall(savedState);
    
                RunRegistration(OCX, false, false);
                RunRegistration(Office, true, false);
                RunRegistration(Word, true, false);
                RunRegistration(Excel, true, false);
            }
            public override void Rollback(System.Collections.IDictionary savedState) {
                base.Rollback(savedState);
            
                // Uninstall during the Rollback, just in case something happens in the installation.
                RunRegistration(OCX, false, false);
                RunRegistration(Office, true, false);
                RunRegistration(Word, true, false);
                RunRegistration(Excel, true, false);
            }
            public override void Commit(System.Collections.IDictionary savedState) {
                base.Commit(savedState);
                // Nothing needs to be done during Commit.
            }
            static void Main() { }
            /// <summary>
            /// A method to run either regasm or regsvr32 to register a given DLL or OCX.
            /// </summary>
            /// <param name="fileName">The name of the file to register.</param>
            /// <param name="regasm">True to run regasm, false to run regsvr32.exe.</param>
            /// <param name="install">True to install, false to uninstall.</param>
        private static void RunRegistration(string fileName, bool regasm, bool install)     {
                try {
                    Process reg = new Process();
    
                    string args = string.Empty;
                    if (!install) {
                        // If we're not installing, set it to uninstall.
                        args += " -u ";
                    }
    
                    if (regasm) {
                        // Use System.Runtime... to get the latest operating directory where regasm would be located.
                        reg.StartInfo.FileName = Path.Combine(System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory(), "regasm.exe");
                    }
                    else {
                        reg.StartInfo.FileName = "regsvr32.exe";
                        // Run regsvr32 silently or else it displays a dialog that the OCX was registered successfully.
                        args += " /s ";
                    }
                    args += " \"" + Path.Combine(InstallationPath, fileName) + "\"";
                    reg.StartInfo.Arguments = args;
                    reg.StartInfo.UseShellExecute = false;
                    reg.StartInfo.CreateNoWindow = true;
                    reg.StartInfo.RedirectStandardOutput = true;
                    reg.Start();
                    reg.WaitForExit();
                    reg.Close();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
