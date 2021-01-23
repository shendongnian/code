     private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchableString) && !string.IsNullOrEmpty(FullRichtxt))
            {
                var SplitedTxt = FullRichtxt.Split('\n').ToList<string>();
                List<string> filterlist = SplitedTxt.Where(x => x.Contains(contx.SearchableString)).ToList<string>();
                string FilterString=string.Empty;
                foreach(string str in filterlist)
                {
                    FilterString+=str+"\n";
                }
               (RichTextBox1 as  RichTextBox).AppendText(FilterString);
            }
        }
