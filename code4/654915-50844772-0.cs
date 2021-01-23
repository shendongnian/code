     public void SetReadonlyControls(Control.ControlCollection controlCollection)
            {
                if (controlCollection == null)
                {
                    return;
                }
                foreach (RadioButton r in controlCollection.OfType<RadioButton>())
                {
                    r.Enabled = false; //RadioButtons do not have readonly property
                }
                foreach (ComboBox c in controlCollection.OfType<ComboBox>())
                {//AQUE
                    var text = new TextBox();
                    controlCollection.Add(text);
                    text.Text = c.Text;
                    text.Location = c.Location;
                    text.Size = c.Size;
                    text.Visible = true;`enter code here`
                    c.Visible = false;
                   /* c.Enabled = false;//ComboBoxes do not have readonly property
                    c.ForeColor = System.Drawing.Color.White;
                   c.DropDownStyle = ComboBoxStyle.Simple;*/
                }
                foreach (TextBoxBase c in controlCollection.OfType<TextBoxBase>())
                {
                    c.ReadOnly = true;
                }
                foreach (DateTimePicker c in controlCollection.OfType<DateTimePicker>())
                {
                    c.Enabled = false;
                }
            }
