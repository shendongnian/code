    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                HtmlElementCollection bigFontTags = ((WebBrowser)sender).Document.GetElementsByTagName("b");
                string[] textPieces=new string[bigFontTags.Count];
                for (int i = 0; i < bigFontTags.Count; i++)
                {
                    textPieces[i] = bigFontTags[i].InnerText;
                }
                //process text
                string bigText = String.Join(" ", textPieces);
                MessageBox.Show(bigText);
            }
