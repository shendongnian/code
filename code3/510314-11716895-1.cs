            foreach (Control currentControl in this.Controls)
            {
                if (currentControl is PictureBox)
                {
                    if (((PictureBox)currentControl).Tag.ToString().Equals("accept"))
                    {
                        string controlId = currentControl.Name.Remove(0, 11);
                        string labelName = string.Concat("lbl_roomid", controlId);
                        string txtName = string.Concat("txt_sdate", controlId);
                        this.DoMagic(this.Controls.Find(labelName, true)[0] as Label, this.Controls.Find(txtName, true)[0] as TextBox);
                    }
                }
            }
