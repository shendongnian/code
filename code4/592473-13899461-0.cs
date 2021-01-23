      private void Form2_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (textBox1.CausesValidation)
                {
                    textBox1.CausesValidation = false;
                    Close();
                }
            }
