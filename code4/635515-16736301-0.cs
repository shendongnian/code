    if (TextBox1.Text != "")
            {
                int b=0;
                while (b < RadioButtonList1.Items.Count)
                {
                    if (TextBox1.Text == RadioButtonList1.Items[b].Text)
                    {
                         Image1.ImageUrl = "~/Images/" + Textbox1.Text + ".png";
                        break;
                    }
                    b++;
                }
            }
