            TextBox myTextBox = null;
            Control[] controls = TextInfoGroupBox.Controls.Find("InnerTextBoxName", true);
            foreach (Control c in controls)
            {
                if (c is TextBox)
                {
                    myTextBox = c as TextBox;
                    break;
                }
            }
