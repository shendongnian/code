            PdfReader pdfReader = new PdfReader(filename);
                        
            IList<Dictionary<string, object>> bookmarks = SimpleBookmark.GetBookmark(pdfReader);
            
           
                      for(int i=0;i<bookmarks.Count;i++)
            {
                   MessageBox.Show(bookmarks[i].Values.ToArray().GetValue(0).ToString());
                if (bookmarks[i].Count > 3)
                {
                    MessageBox.Show(bookmarks[i].ToList().Count.ToString());
                }
            //    MessageBox.Show(s.GetValue(2).ToString());
            }
                        //richTextBox1.Text=bookmarks.
            
