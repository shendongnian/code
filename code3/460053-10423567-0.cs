                foreach (ListViewItem keyword in Keywords.Items)
                {
                    System.Text.RegularExpressions.Regex oKeyword = new System.Text.RegularExpressions.Regex(@"\b" + keyword.Text + @"\b");
                    foreach (System.Text.RegularExpressions.Match match in oKeyword.Matches(rtb.Text))
                    {
                        int index = match.Index;
                        int length = match.Length;
                        rtb.Select(index, length);
                        //This next bit is made available through the use of http://www.codeproject.com/Articles/9196/Links-with-arbitrary-text-in-a-RichTextBox
                        rtb.InsertLink(match.Value);  
                    }
                }
