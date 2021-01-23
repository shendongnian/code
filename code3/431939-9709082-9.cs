    private void runApp()
    {
      VBA.VBComponent f = null;
      VBA.VBComponent f2 = null;
      Microsoft.Office.Interop.Access.Application app = null;
      object Missing = System.Reflection.Missing.Value;
      String function = "Run_Report";
      Object tempForm = null;
    
      try
      {
    	 app = new Microsoft.Office.Interop.Access.Application();
    	 app.Visible = true;
    	 app.OpenCurrentDatabase("C:\\Path\\To\\MDB\\File.mdb", false, "");
    
    	 String[] sCode = {
    		    "Public Sub TempFormCall()\r\n" +
    		    "   Call " + function + "()\r\n" +
    		    "End Sub\r\n",
    
    		    "Public Function instantiateTempForm() As Object\r\n" +
    		    "    Set instantiateTempForm = New TEMP_FORM\r\n" +
    		    "End Function"
    		};
    
    	 //Step 1: Append a new class with which to call the run function.
    	 f = app.VBE.ActiveVBProject.VBComponents.Add(VBA.vbext_ComponentType.vbext_ct_MSForm);
    	 f.Name = "TEMP_FORM";
    	 f.CodeModule.AddFromString(sCode[0]);
    
    	 //Step 2: Append a new module to instantiate the form object
    	 f2 = app.VBE.ActiveVBProject.VBComponents.Add(VBA.vbext_ComponentType.vbext_ct_StdModule);
    	 f2.Name = "TEMP_MODULE";
    	 f2.CodeModule.AddFromString(sCode[1]);
    
    	 //Step 3: Get a reference to a new TempForm object
    	 tempForm = app.Run("instantiateTempForm", ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing);
    
    	 //Step 4: Call the method on the TempForm object.
    	 Microsoft.VisualBasic.Interaction.CallByName(tempForm, "TempFormCall", Microsoft.VisualBasic.CallType.Method);
    
    	 
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
    
    	 GC.Collect();
    	 GC.WaitForPendingFinalizers();
    
    	 //Not so confident about this part
    	 if (f != null) Marshal.FinalReleaseComObject(f);
    	 if (f2 != null) Marshal.FinalReleaseComObject(f2);
    	 if (tempForm != null) Marshal.FinalReleaseComObject(tempForm);
    	 if (app != null) Marshal.FinalReleaseComObject(app);
      }
    }
	   
	   
