    	Document wordFile = new Document();
		//OTHER VARIABLES
		Object oClassType = "Word.Document.8";
		Object oTrue = true;
		Object oFalse = false;
		Object oMissing = System.Reflection.Missing.Value;
		private void BtnInserirImagem_Click(object sender, RoutedEventArgs e)
		{
			//Init Word App Object here
			Microsoft.Office.Interop.Word.Application oWord = new Microsoft.Office.Interop.Word.Application();
			foreach (MyDocsList row in dataGridList.Items)
			{
				wordFile = oWord.Documents.Open(row.filename);
				//pass the Word App instance
				addWatermark(wordFile, row.filename, oWord);
			}
			// Quitting oWord outside of the loop
			oWord.Quit(ref oMissing, ref oMissing, ref oMissing);
		}
		//added the Word App instance to the signature
		private void addWatermark(Document doc, object filename, Microsoft.Office.Interop.Word.Application oWord)
		{
			object refmissing = System.Reflection.Missing.Value;
			string watermarkPath = Directory.GetCurrentDirectory() + "\\fundo.jpg";
			if (File.Exists(watermarkPath))
			{
				object linkToFile = false;
				object saveWithDocument = true;
				WdHeaderFooterIndex hfIndex = WdHeaderFooterIndex.wdHeaderFooterPrimary;
				HeaderFooter headerFooter;
				for (int i = 1; i < doc.Sections.Count + 1; i++)
				{
					if (doc.Sections[i].Headers != null)
					{
						headerFooter = doc.Sections[i].Headers[hfIndex];
					}
					else if (doc.Sections[i].Footers != null)
					{
						headerFooter = doc.Sections[i].Footers[hfIndex];
					}
					else
					{
						headerFooter = null;
					}
					if (headerFooter != null)
					{
						try
						{
							Microsoft.Office.Interop.Word.Shape watermarkShape;
							watermarkShape = headerFooter.Shapes.AddPicture(watermarkPath, ref linkToFile, ref saveWithDocument, ref refmissing,
																			ref refmissing, ref refmissing, ref refmissing, ref refmissing);
							watermarkShape.Left = Convert.ToSingle(WdShapePosition.wdShapeLeft);
							watermarkShape.Top = Convert.ToSingle(WdShapePosition.wdShapeCenter);
						}
						catch (System.Runtime.InteropServices.COMException e)
						{
							MessageBoxResult result = MessageBox.Show(String.Format("{0} - Error Code = {1}", e.Message, e.ErrorCode));
							throw e;
						}
					}
				}
				oWord.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument;
				oWord.ActiveWindow.ActivePane.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdPrintView;
			}
			else
			{
				MessageBoxResult result = MessageBox.Show("Could not find watermark image");
			}
			//THE LOCATION WHERE THE FILE NEEDS TO BE SAVED
			string outstringFile = "";
			string pathfile = System.IO.Path.GetDirectoryName(filename);
			string filenameFile = System.IO.Path.GetFileName(filename);
			outstringFile = pathfile + "\\OG" + filenameFile;
			Object oSaveAsFile = (Object)(outstringFile);
			wordFile.SaveAs(ref oSaveAsFile, ref oMissing, ref oMissing, ref oMissing,
				ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
				ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
				ref oMissing, ref oMissing);
			//CLOSING THE FILE
			wordFile.Close(ref oFalse, ref oMissing, ref oMissing);
		}
