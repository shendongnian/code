    using System;
    using WindowsInstaller;
    using System.Runtime.InteropServices;
    using System.Reflection;
    
    namespace Post_Setup_Scripting
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                if (args.Length != 2)
                {
                    Console.WriteLine("Incorrect args.");
                    return;
                }
    
                //arg 1 - path to MSI
                string PathToMSI = args[0];
                //arg 2 - path to assembly
                string PathToAssembly = args[1];
    
                Type InstallerType;
                WindowsInstaller.Installer Installer;
                InstallerType = Type.GetTypeFromProgID("WindowsInstaller.Installer");
                Installer = (WindowsInstaller.Installer)Activator.CreateInstance(InstallerType);
    
                Assembly Assembly = Assembly.LoadFrom(PathToAssembly);
                string AssemblyStrongName = Assembly.GetName().FullName;
                string AssemblyVersion = Assembly.GetName().Version.ToString();
    
                string SQL = "SELECT `Key`, `Name`, `Value` FROM `Registry`";
                WindowsInstaller.Database Db = Installer.OpenDatabase(PathToMSI, WindowsInstaller.MsiOpenDatabaseMode.msiOpenDatabaseModeDirect);
                WindowsInstaller.View View = Db.OpenView(SQL);
                View.Execute();
                WindowsInstaller.Record Rec = View.Fetch();
                while (Rec != null)
                {
                    for (int c = 0; c <= Rec.FieldCount; c++)
                    {
                        string Column = Rec.get_StringData(c);
                        Column = Column.Replace("[AssemblyVersion]", AssemblyVersion);
                        Column = Column.Replace("[AssemblyStrongName]", AssemblyStrongName);
                        Rec.set_StringData(c, Column);
                        View.Modify(MsiViewModify.msiViewModifyReplace, Rec);
                        Console.Write("{0}\t", Column);
                        Db.Commit();
                    }
                    Console.WriteLine();
                    Rec = View.Fetch();
                }
                View.Close();
    
                GC.Collect();
                Marshal.FinalReleaseComObject(Installer);
    
                Console.ReadLine();
            }
        }
    }
