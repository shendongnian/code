    public string Highlight(string InputTxt)
        {
            string[] separators = { ",", ".", "!", "?", ";", ":", " " };
            string[] words = InputTxt.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string strSearch = TextBox1.Text;
            string[] Strseacharr = strSearch.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in Strseacharr)
            {
                InputTxt = InputTxt.Replace(item, ReplaceKeyWords(item));
            }
            return InputTxt;
        }
        public string ReplaceKeyWords(string m)
        {
            return "<span class=highlight>" + m + "</span>";
        }
