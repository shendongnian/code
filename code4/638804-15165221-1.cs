    string s = "";
            foreach (Control item in this.Controls)
            {
                if (item is CheckBox)
                {
                    CheckBox temp = item as CheckBox;
                    if (temp.Checked)
                    {
                        s += temp.ToolTip + ", ";
                    }
                }
            }
    s = s.Substring(0,s.length-3);
