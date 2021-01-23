	using Word = Microsoft.Office.Interop.Word;
	public void CreatePackage(string filePath, string longText)
	{
		Word.Application wordApp = new Word.Application();
		Word.Document doc = wordApp.Documents.Open("MyOriginalDoc.docx");
		try
		{
			//If the document is protected Select() will throw an exception
			if (doc.ProtectionType != Word.WdProtectionType.wdNoProtection)
			{
				doc.Unprotect();
			}
			foreach (Microsoft.Office.Interop.Word.FormField f in doc.FormFields)
			{
				//My situation prohibits me from adding bookmarks to the document, so instead I'm
				//using sentinel values that I search the doc for.
				if (f.Result.Equals("MySentinalValue"))
				{
					//You need some easily removed dummy characters in the field for this to work.
					f.Result = "****";	
					
					//If you don't follow these next three steps you'll end up replacing the formfield
					//rather than inserting text into it
					f.Range.Select();
					wordApp.Selection.Collapse();				
					wordApp.Selection.MoveRight(Word.WdUnits.wdCharacter, 1);
					
					//Insert the text
					wordApp.Selection.TypeText(longText);
					
					//Now remove the dummy characters. If you don't re-select the range, Find won't catch the 
					//the first one.
					f.Range.Select();
					Word.Find find = wordApp.Selection.Find;
					object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
					find.ClearFormatting();
					find.Text = "*";
					find.Replacement.ClearFormatting();
					find.Replacement.Text = "";
					find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);
				}
			//Restore the doc protections. Note that if NoReset != true all data entered in fields will be lost
			doc.Protect(Word.WdProtectionType.wdAllowOnlyFormFields, true);
			doc.SaveAs(filePath);
		}
		catch (System.Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		finally
		{
			doc.Close();
			wordApp.Quit();
		}
	}
