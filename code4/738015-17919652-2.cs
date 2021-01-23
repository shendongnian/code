            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(ms, true))
            {
                //get all the text elements
                IEnumerable<Text> texts = wordDoc.MainDocumentPart.Document.Body.Descendants<Text>();
                //filter them to the ones that contain the QuoteLeft char
                var tokenTexts = texts.Where(t => t.Text.Contains(oldString));
                foreach (var token in tokenTexts)
                {
                    //get the parent element
                    var parent = token.Parent;
                    //deep clone this Text element
                    var newToken = token.CloneNode(true);
                    //split the text into an array using a regex of all line terminators
                    var lines = Regex.Split(myNewString, "\r\n|\r|\n");
                    //change the original text element to the first line
                    ((Text) newToken).Text = lines[0];
                    //if more than one line
                    for (int i = 1; i < lines.Length; i++)
                    {
                        //append a break to the parent
                        parent.AppendChild<Break>(new Break());
                        //then append the next line
                        parent.AppendChild<Text>(new Text(lines[i]));
                    }
                    //insert it after the token element
                    token.InsertAfterSelf(newToken);
                    //remove the token element
                    token.Remove();
                }
                wordDoc.MainDocumentPart.Document.Save();
            }
