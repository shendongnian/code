    private void RemoveLines(List<string> Keywords)
        {
            String regex = string.Empty;
            string NewText = richTextBox1.Text;            
            Regex MyRegex = null;
            foreach (string keyword in Keywords)
            {
                regex = String.Format(@"^.*\W{0}\W.*$",keyword);
                MyRegex = new Regex(regex, RegexOptions.Multiline);
                NewText = MyRegex.Replace(NewText, Environment.NewLine);
            }
            //Remove blank lines
            NewText = Regex.Replace(NewText, @"^\s+$[\r\n]*", "", RegexOptions.Multiline); 
            richTextBox1.Text = NewText;
            richTextBox1.Refresh();
        }  
 
