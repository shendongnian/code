                    byte[] bytes = System.IO.File.ReadAllBytes(ofd.FileName);
                byte[] checksum = null;
                if (optMD5.IsChecked==true)
                {
                    MD5 md5 = System.Security.Cryptography.MD5.Create();//.MD5CryptoServiceProvider();
                    checksum=new byte[1024];
                    checksum = md5.ComputeHash(bytes);
                }
                else if (optSHA1.IsChecked == true)
                {
                    SHA1 sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                    checksum = sha1.ComputeHash(bytes);
                }
                else {
                    MessageBox.Show("No option selected.");
                    return;
                }
                //string schecksum = BitConverter.ToString(checksum);//ASCIIEncoding.ASCII.GetString(checksum);
                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sb = new StringBuilder();
                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < checksum.Length; i++)
                {
                    sb.Append(checksum[i].ToString("x2"));
                }
                // Return the hexadecimal string.
                //return sb.ToString();
                MessageBox.Show("checksum-1 = " + sb.ToString() + Environment.NewLine + "checksum-2 = " + txtChecksum.Text);
