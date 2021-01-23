            label1.Text = "Pazartesi";
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            byte sayi = Convert.ToByte(numericUpDown1.Value);
            switch (sayi)
            {
                case 1:
                    label1.Text="Pazartesi";
                    break;
                case 2:
                    label1.Text="Salı";
                    break;
                case 3:
                    label1.Text = "Çarşamba";
                    break;
                case 4:
                    label1.Text = "Perşembe";
                    break;
                case 5:
                    label1.Text = "Cuma";
                    break;
                case 6:
                    label1.Text = "Cumartesi";
                    break;
                case 7:
                    label1.Text = "Pazar";
                    break;
            }
            RadioButton selectedRadio = GetSelectedRadioButton();
            switch(selectedRadio.Name)
            { 
               case rankbtn_1.Name:
                    this.BackColor = Color.Red;
                    break;
               case rankbtn_2.Name:
                    this.BackColor = Color.White;
                    break;
               //Repeat for the other buttons.
            }
       }
       private RadioButton GetSelectedRadioButton()
       {
                    foreach (Control c in groupBox1.Controls)
                {
                    if (c.GetType() == typeof(RadioButton))
                    {
                        RadioButton rb = c as RadioButton;
                        if (rb.Checked)
                        {
                           return rb;
                        }
                    }
                }
       }           
