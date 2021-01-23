        public Boolean CheckIPValid(String strIP)
        {
            //  Split string by ".", check that array length is 4
            string[] arrOctets = strIP.Split('.');
            if (arrOctets.Length != 4)
                return false;
            //Check each substring checking that parses to byte
            byte obyte = 0;
            foreach (string strOctet in arrOctets)
                if (byte.TryParse(strOctet, out obyte)) 
                    return false;
            return true;
        }
  
