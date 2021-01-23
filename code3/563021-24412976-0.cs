       private void textBox2_Validating(object sender, CancelEventArgs e)
            {
                if (DoSomething(textBox2))
                {
                    textBox3.Text = textBox2.Text;
                }
                else
                {
                    e.Cancel = true; //cancel the validation.
                }
                
            }
