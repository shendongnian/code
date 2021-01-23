    		using System.Security.Cryptography;
		static byte[] key = ASCIIEncoding.ASCII.GetBytes("!)@(#*$&"); //Encrypt Key
        static byte[] IV= ASCIIEncoding.ASCII.GetBytes("qwertyui"); //Initial Value
        protected void Encrypt_Click(object sender, EventArgs e)
        {
             if (String.IsNullOrEmpty(txtPwd.Text))
            {
                throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
            } 
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, 
                cryptoProvider.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(txtPwd.Text);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            txtPwd.Text= Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }
        
        protected void Decrypt_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPwd.Text))
            {
                throw new ArgumentNullException
                   ("The string which needs to be decrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(TextBox1.Text));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(key, IV), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            txtPwd.Text=reader.ReadToEnd();
        }
