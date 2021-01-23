    TextBox2.Text = System.Text.RegularExpressions.Regex.Replace(
                        TextBox1.Text, 
                        @"^.{49}", 
                        "", 
                        RegexOptions.Multiline );
