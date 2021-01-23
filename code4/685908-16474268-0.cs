    private void button1_Click(object sender, EventArgs e)
    {
            string[] lines = value.Split(Environment.NewLine.ToCharArray()); 
            foreach (string l in lines)
            {
                if (l.IndexOf("Processing")==0)
                {
                   textBox4.Text = textBox4.Text + l + Environment.NewLine;
                }
        
                MatchCollection matches2 = Regex.Matches(l, "\"([^\"]*)\"");
                foreach (Match match2 in matches2)
                {
                    foreach (Capture capture2 in match2.Captures)
                    {              
                        textBox4.Text = textBox4.Text + Environment.NewLine + capture2.Value;   
                    }
                }
            }
        }   
