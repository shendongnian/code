                var strOriginal = richTextBox1.Text;
                byte[] byt = System.Text.Encoding.ASCII.GetBytes(strOriginal);
                // convert the byte array to a Base64 string
                string strModified = Convert.ToBase64String(byt);
                richTextBox1.Text = "" + strModified;
