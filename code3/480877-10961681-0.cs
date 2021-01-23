    string s = richTextBox1.Text;
            var k = Regex.Split(s, "\\n", RegexOptions.Multiline);
            foreach (string str in k)
            {
                //do what you want
                MessageBox.Show(str);
            }
