    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using VBA = Microsoft.Vbe.Interop;
    
    namespace CaptureVBAErrorsTest
    {
        class CaptureVBAErrors
        {
            public void runApp(string databaseName, string function)
            {
                VBA.VBComponent f = null;
                VBA.VBComponent f2 = null;
                Microsoft.Office.Interop.Access.Application app = null;
                object Missing = System.Reflection.Missing.Value;
                Object tempObject = null;
    
                try
                {
                    app = new Microsoft.Office.Interop.Access.Application();
                    app.Visible = true;
                    app.OpenCurrentDatabase(databaseName, false, "");
    
                    //Step 1: Append a new VBA class with which to call the run function.
    
                    //Create a Guid to append to the object name, so that in case they somehow get "stuck",
                    //the temp objects won't interfere with other objects each other (if there are multiples).
                    string tempGuid = Guid.NewGuid().ToString("N");
    
                    f = app.VBE.ActiveVBProject.VBComponents.Add(VBA.vbext_ComponentType.vbext_ct_ClassModule);
                    
                    //We must set the Instancing to 2-PublicNotCreatable
                    f.Properties.Item("Instancing").Value = 2;
                    f.Name = "TEMP_CLASS_" + tempGuid;
                    f.CodeModule.AddFromString(
                        "Public Sub TempClassCall()\r\n" +
                        "   Call " + function + "\r\n" +
                        "End Sub\r\n");
    
                    //Step 2: Append a new module to instantiate the form object
                    f2 = app.VBE.ActiveVBProject.VBComponents.Add(VBA.vbext_ComponentType.vbext_ct_StdModule);
                    f2.Name = "TEMP_MODULE";
                    f2.CodeModule.AddFromString(string.Format(
                        "Public Function instantiateTempClass_{0}() As Object\r\n" +
                        "    Set instantiateTempClass_{0} = New TEMP_CLASS_{0}\r\n" +
                        "End Function"
                        ,tempGuid));
    
                    //Step 3: Get a reference to a new TEMP_CLASS_* object
                    tempObject = app.Run("instantiateTempClass_" + tempGuid, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing);
    
                    //Step 4: Call the method on the TempForm object.
                    Microsoft.VisualBasic.Interaction.CallByName(tempObject, "TempClassCall", Microsoft.VisualBasic.CallType.Method);
    
    
                }
                catch (COMException e)
                {
                    MessageBox.Show("A VBA Exception occurred in file:" + e.Message);
                }
                catch (Exception e)
                {
                    MessageBox.Show("A general exception has occurred: " + e.StackTrace.ToString());
                }
                finally
                {
                    //Clean up
                    if (app != null)
                    {
                        app.VBE.ActiveVBProject.VBComponents.Remove(f);
                        app.VBE.ActiveVBProject.VBComponents.Remove(f2);
                        app.Quit(Microsoft.Office.Interop.Access.AcQuitOption.acQuitSaveNone);
                    }
    
                    if (f != null) Marshal.FinalReleaseComObject(f);
                    if (f2 != null) Marshal.FinalReleaseComObject(f2);
                    if (tempObject != null) Marshal.FinalReleaseComObject(tempObject);
                    if (app != null) Marshal.FinalReleaseComObject(app);
    
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }
    }
