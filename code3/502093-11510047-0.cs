        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {            
            char[] charArr = { 'a', 'b', 'c' };  //spec out what is acceptable here
            foreach (char c in charArr)
            {
                if (e.KeyChar.CompareTo(c) > 0)
                {
                    e.Handled = true;                    
                }
                else
                {
                    e.Handled = false;
                }
            }
        }
