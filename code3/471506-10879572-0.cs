    private void txtSmsMessage_TextChanged(object sender, EventArgs e)
            {
                //sadece latin karakterlerin girilmesi saglanıyor.
                string str = ((TextBox)sender).Text;
                byte[] key = null;
                if (!string.IsNullOrEmpty(str))
                {
                    key = Encoding.Unicode.GetBytes(str.Substring(str.Length - 1, 1));
                    if (Convert.ToInt32(key[1]) != 0 || (Convert.ToInt32(key[0]) < 32 && Convert.ToInt32(key[0]) > 127))
                    {
                        txtSmsMessage.Text = txtSmsMessage.Text.Substring(0, str.Length - 1);
                        txtSmsMessage.SelectionStart = txtSmsMessage.Text.Length;
                        return;
                    }
                }
    }
