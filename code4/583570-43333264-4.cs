    private static string privateKey = String.Empty;
    private static void generateKeys()
    {
        int dwLen = 2048;
        RSACryptoServiceProvider csp = new RSACryptoServiceProvider(dwLen);
        privateKey = csp.ToXmlString(true).Replace("><",">\r\n");
    }
    public static string Encrypt(string data2Encrypt)
    {
        try
        {
            generateKeys();
            RSAx rsax = new RSAx(privateKey, 2048);
            rsax.RSAxHashAlgorithm = RSAxParameters.RSAxHashAlgorithm.SHA512;
            byte[] CT = rsax.Encrypt(Encoding.UTF8.GetBytes(data2Encrypt), false, true); // first bool is for using private key (false forces to use public), 2nd is for using OAEP
            return Convert.ToBase64String(CT);
        }
        catch (Exception ex) 
        { 
            // handle exception
            MessageBox.Show("Error during encryption: " + ex.Message);
            return String.Empty;
        }
    }
    public static string Decrypt(string data2Decrypt)
    {
        try
        {
            RSAx rsax = new RSAx(privateKey, 2048);
            rsax.RSAxHashAlgorithm = RSAxParameters.RSAxHashAlgorithm.SHA512;
            byte[] PT = rsax.Decrypt(Convert.FromBase64String(data2Decrypt), true, true); // first bool is for using private key, 2nd is for using OAEP
            return Encoding.UTF8.GetString(PT);
        }
        catch (Exception ex) 
        { 
            // handle exception
            MessageBox.Show("Error during encryption: " + ex.Message);
            return String.Empty;
        }
    }
