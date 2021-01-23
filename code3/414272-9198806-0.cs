        private void Button1Click(object sender, RibbonControlEventArgs e)
        {
            object oMissing = System.Reflection.Missing.Value;
            object dowdSaveChanges = WdSaveOptions.wdDoNotSaveChanges;
            try
            {                
                 Globals.ThisDocument.Application.ActiveDocument.Close(ref dowdSaveChanges, ref oMissing, ref oMissing);                
            }
            catch (ThreadAbortException t)
            {
                Globals.ThisDocument.ThisApplication.Quit(ref dowdSaveChanges, ref oMissing, ref oMissing);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
