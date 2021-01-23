            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                // look for the expected key 
                if (keyData == Keys.Alt && keyData == Keys.V)
                {
                    checkBox1.Checked = true;
                    return true;
                }
                else
                {
                    checkBox1.Checked = false;
                    return false;
                }
            }
