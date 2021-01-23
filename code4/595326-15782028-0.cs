    //make some data.
                List<String[]> data = new List<string[]>();
    
                for (int i = 0; i < 10; i++)
                    data.Add(new String[] {"this","is","sparta" });
        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open("yourDocument.docx", true))
                    {
                        var mainPart = wordDoc.MainDocumentPart;
                        var bookmarks = mainPart.Document.Body.Descendants<BookmarkStart>();
                        var bookmark = 
                            from n in bookmarks 
                            where n.Name == "transactions" 
                            select n;
        
                        OpenXmlElement elem = bookmark.First().Parent;
                        //isolate tabel
                        while (!(elem is DocumentFormat.OpenXml.Wordprocessing.Table))
                            elem = elem.Parent;
                        var table = elem; //found
                        //save the row you wanna copy in each time you have data.
                        var oldRow = elem.Elements<TableRow>().Last();
                        DocumentFormat.OpenXml.Wordprocessing.TableRow row = (TableRow)oldRow.Clone();
                        //remove old row
                        elem.RemoveChild<TableRow>(oldRow);
                        foreach (String[] s in data)
                        {
                            DocumentFormat.OpenXml.Wordprocessing.TableRow newrow = (TableRow)row.Clone();
                            var cells = newrow.Elements<DocumentFormat.OpenXml.Wordprocessing.TableCell>();
                            //we know we have 3 cells
                            for(int i = 0; i < cells.Count(); i++)
                            {
                                var c = cells.ElementAt(i);
                                var run = c.Elements<Paragraph>().First().Elements<Run>().First();
                                var text = run.Elements<Text>().First();
                                text.Text = s[i];
                            }
                            table.AppendChild(newrow);
                        }
                    }
