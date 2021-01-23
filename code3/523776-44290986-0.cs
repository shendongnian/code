        public void RunMailMerge()
        {
            try
            {
                object isTrue = true;
                object notTrue = false;
                Microsoft.Office.Interop.Word.Document wordDoc = new Microsoft.Office.Interop.Word.Document();
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                string filename = @"C:\<path>\<the file you created>.docx";
                wordDoc = wordApp.Documents.Add(Template: filename);
                wordApp.Visible = true;
                object format = Microsoft.Office.Interop.Word.WdOpenFormat.wdOpenFormatAuto;
                wordDoc.MailMerge.OpenDataSource(@"C:\Users\<username>\Documents\My Data Sources\<your connection file>.odc",
                          ref format,
                          ref notTrue,    // ConfirmConversion
                          ref isTrue      // Set as ReadOnly so the user can't overwrite the document
                          );
                // Check the QueryString to see what is already there, add your parameters as needed.  In my case I added "WHERE AppointmentID = 4"
                wordDoc.MailMerge.DataSource.QueryString = "SELECT * FROM \"vAppointment\" WHERE AppointmentID = 4";
                wordDoc.MailMerge.Execute(ref notTrue);
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                string s = ex.StackTrace;
                string msg = t + Environment.NewLine + s;
            }
        }
