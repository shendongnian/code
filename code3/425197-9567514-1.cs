    private void HandleKeyDownEvent(object sender, KeyEventArgs e)
            {
                RichTextBox rtb = sender as RichTextBox;
                if (rtb != null)
                {
                    //text to scroll up relative to caret
                    if (e.Key == Key.Down)
                    {
                        Block paragraph;
    
                        //get the whitespace paragraph at end of documnent
                        paragraph = 
                                rtb.Document.Blocks
                                    .Where(x => x.Name == "lastParagraph")
                                    .FirstOrDefault();
    
                        // if there is no white space paragraph create it
                        if (paragraph == null)
                        {
                            paragraph = new Paragraph { Name = "lastParagraph", Margin = new Thickness(0) };
    
                            //add to the end of the document
                            rtb.Document.Blocks.InsertAfter(rtb.Document.Blocks.LastBlock, paragraph);
                        }
    
                        // if viewport larger than document, add whitespace content to fill view port
                        if (rtb.ExtentHeight < rtb.ViewportHeight)
                        {
                            Thickness margin = new Thickness() { Top = rtb.ViewportHeight - rtb.ExtentHeight };
                                    margin.Bottom = rtb.ViewportHeight - rtb.ExtentHeight;
                                    paragraph.Margin = margin;
                                
                        }
    
                        // if the document has been scrolled to the end or doesn't fill the view port
                        if (rtb.VerticalOffset + rtb.ViewportHeight == rtb.ExtentHeight)
                        {
                            // and a line to the white paragraph
                            paragraph.ContentEnd.InsertLineBreak();   
                        }
                        
                        //move the text up relative to caret
                        rtb.LineDown();
                    }
                    // text is to scroll download relative to caret
                    if (e.Key == Key.Up)
                    {
                        // get whitespace at start of document
                        Block paragraph;
                        paragraph =
                                rtb.Document.Blocks
                                    .Where(x => x.Name == "firstParagraph")
                                    .FirstOrDefault();
    
                        //if whitespace paragraph is null append a new one
                        if (paragraph == null)
                        {
                            paragraph = new Paragraph { Name = "firstParagraph", Margin = new Thickness(0) };
                            rtb.Document.Blocks.InsertBefore(rtb.Document.Blocks.FirstBlock, paragraph);
                        }
    
                        // up document is at top add white space 
                        if (rtb.VerticalOffset == 0.0)
                        {
                            paragraph.ContentStart.InsertLineBreak();
                        }
    
                        //move text one line down relative to caret
                        rtb.LineUp();
                    }
                }
            }
