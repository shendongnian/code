     private void butns_Click(object sender, EventArgs e)
        {
            Button butns = sender as Button;
            string btnName = butns.Name;
            string Id = btnName.Substring(3);
            string txtName = "txt" + Id;
            listBox2.Items.Add("text values " + GetValue(txtName));
        }
        private string GetValue(string name)
        {
            TextBox txt = new TextBox();
            txt.Name = name;
            foreach (Control ctl in this.Controls)
            {
                if (ctl is FlowLayoutPanel)
                {
                    foreach (Control i in ctl.Controls)
                    {
                        if (((TextBox)i).Name == txt.Name)
                        {
                            txt = (TextBox)i;
                            return txt.Text;
                        }
                    }
                }
            }
            return txt.Text;
        }
    }
