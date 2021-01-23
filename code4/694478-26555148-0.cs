        private bool RemoveBlankPage()
        {
            Word.Application wordapp = null;
            Word.Document doc = null;
            Word.Paragraphs paragraphs=null;
            try
            {
                // Start Word APllication and set it be invisible
                wordapp = new Word.Application();
                wordapp.Visible = false;
                doc = wordapp.Documents.Open(wordPath);
                paragraphs = doc.Paragraphs;
                foreach (Word.Paragraph paragraph in paragraphs)
                {
                    if (paragraph.Range.Text.Trim() == string.Empty)
                    {
                        paragraph.Range.Select();
                        wordapp.Selection.Delete();
                    }
                }
                // Save the document and close document
                doc.Save();
                ((Word._Document)doc).Close();
                // Quit the word application
                ((Word._Application)wordapp).Quit();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception Occur, error message is: "+ex.Message);
                return false;
            }
            finally
            { 
                // Clean up the unmanaged Word COM resources by explicitly
                // call Marshal.FinalReleaseComObject on all accessor objects
                if (paragraphs != null)
                {
                    Marshal.FinalReleaseComObject(paragraphs);
                    paragraphs = null;
                }
                if (doc != null)
                {
                    Marshal.FinalReleaseComObject(doc);
                    doc = null;
                }
                if (wordapp != null)
                {
                    Marshal.FinalReleaseComObject(wordapp);
                    wordapp = null;
                }
            }
            return true;
        }
