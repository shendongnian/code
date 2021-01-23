     if (e.KeyCode == (Keys.Back))
     {
            if(textBox1.Text.Length >=3)
            {
                 if (textBox1.Text.Contains("-"))
                 {
                     textBox1.Text.Replace("-", "");
                 }
            }
     }
