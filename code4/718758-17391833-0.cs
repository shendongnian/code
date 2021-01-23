    static public string GetMd5Sum(string str)
        {
            //vBulletin uses UTF8 as strings, so you need to pass the user input string as UTF8 also
            Encoder enc = System.Text.Encoding.UTF8.GetEncoder();
            //Create a byte[] array to store the new UTF8 string
            byte[] utf8text = new byte[str.Length];
            //Pass the string to the byte[] array
            enc.GetBytes(str.ToCharArray(), 0, str.Length, utf8text , 0, true);
            //Hash the byte[] array with our UTF8 string inside
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(utf8text);
            //Build the final string by converting each byte
            //into hex and appending it to a StringBuilder
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("x2")); //x2 here so the outcome result is all in lowercase, couse vbulleting also stores all in lowercase
            }
            //And return it
            return sb.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Get the user input password as plain text
            string pass = textBox1.Text;
            //Here i provided the salt explicit that i took from the database
            string salt = "N1GOt=>8sdO@E54)PH2@NCm5yI#]3u";
            //Here we convert the plain text password into the first hash
            string p1 = GetMd5Sum(pass);
            //Here we add the salt to the previous hashed password
            string p2 = p1 + salt;
            //Here we hash again the previous hashed password + the salt string
            string final = GetMd5Sum(p2);
            //this was just to the test to see if it all works as intended
            MessageBox.Show(final);
        }
