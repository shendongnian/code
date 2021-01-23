    private static int counter = 0;
    private void renameFields(PdfReader pdfReader)
            {
                try
                {
                    string prepend = String.Format("_{0}", counter++);
                    foreach (DictionaryEntry de in pdfReader.AcroFields.Fields)
                    {
                        pdfReader.AcroFields.RenameField(de.Key.ToString(), prepend + de.Key.ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
