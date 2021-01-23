        private void button1_Click(object sender, EventArgs e)
        {
            string sauce = htm.Text; //htm = textbox
            Regex myRegex = new Regex(@"[0-9]+(?:\.[0-9]*)?", RegexOptions.Compiled);
            foreach (Match iMatch in myRegex.Matches(sauce))
            {
                txt.AppendText(Environment.NewLine + iMatch.Value);//txt= textbox
            }
        }
