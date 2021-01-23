    UnicodeEncoding UE = new UnicodeEncoding();            
            byte[] message = UE.GetBytes(password);
            SHA512Managed hashString = new SHA512Managed();
            string hexNumber = "";
            byte[]  hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hexNumber += String.Format("{0:x2}", x);
            }
            string hashData = hexNumber;
