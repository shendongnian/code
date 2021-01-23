        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            String[] chars = new String[1]{" "};
            if(e.KeyValue == 8)
            {
                var temp = (from string s in textBox1.Text.Split(chars, StringSplitOptions.None)
                                 select s).ToArray();
                temp[temp.Length-1] = "";
                textBox1.Text = String.Join(" ",temp).ToString();
                SendKeys.Send("{END}");
            }
            
        }
