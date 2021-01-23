            string temp = textBox1.Text;
            char[] arra = temp.ToCharArray();
            int total = 0;
            foreach (char t in arra)
            {
                if (char.IsDigit(t))
                {
                    total += int.Parse(t + "");
                }
            }
            textBox1.Text = total.ToString();
