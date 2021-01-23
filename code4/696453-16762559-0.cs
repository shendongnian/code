         protected void AnyTextBox_TextChanged(object sender, EventArgs e)
                {
        
                    if ((string.IsNullOrEmpty(TextBox1.Text)))
                    {
                        TBResult1.Text = "N/A";
                    }
                    else
                    {
                        TBResult1.Text = TextBox1.Text.ToString();
                    }
                }
