    using Word = Microsoft.Office.Interop.Word;
    var wordApplication = new Word.Application();
    var filename = "C:\test.doc";
    Word.Application wordApp = null;
            
    if (wordApplication != null)
        wordApp = wordApplication as Word.ApplicationClass;
    Word.Document wordDoc = null;
    if (File.Exists(fileName.ToString()) && wordApp != null)
            {
                object readOnly = isReadonly;
                object isVisible = true;
                object missing = System.Reflection.Missing.Value;
                wordDoc = wordApp.Documents.Open(ref fileName, ref missing,
                                                 ref readOnly, ref missing, ref missing, ref missing,
                                                 ref missing, ref missing, ref missing, ref missing,
                                                 ref missing, ref isVisible, ref missing, ref missing, ref missing,
                                                 ref missing);
            }
    Word.Document wordDocument = wordDoc as Word.Document;
    int tablecount = wordDocument.Tables.Count;
    wordDocument.Activate();
    for (int i = 1; i <= tablecount; i++)
    {
	Word.Table wTable = wordDocument.Tables[i];
	Word.Cell pCell = wTable.Cell(1, 1);
	if (pCell.Range.Text == "This Act has been update to") 
		{
			MessageBox.Show("Bingo !!!");
			break;
		}
    }
