    private void Paste()
        {
            if (copiedItems != null)
            {
                foreach (string item in copiedItems)
                {
                    if (File.Exists(item))
                    {
                        if (MessageBox.Show(item + "is already exists\r\nDo you want to overwrite it?"
                        , "Overwrite", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                        {
                            File.Copy(item, currAddress, true);
                            infoLabel.Text = "Item(s) Pasted.";
                        }
                        return;
                    }
                    File.Copy(item, currAddress, false);
                    infoLabel.Text = "Item(s) Pasted.";
                }
            }
        }
