        private void button1_Click(object sender, EventArgs e)
        {
            string sauce = htm.Text; // htm = your html box
            Regex myRegex = new Regex(@"(?<=^|>)[^><]+?(?=<|$)", RegexOptions.Compiled);
            foreach (Match iMatch in myRegex.Matches(sauce))
            {
                txt.AppendText(Environment.NewLine + iMatch.Value); //txt = your destination box
            }
        }
