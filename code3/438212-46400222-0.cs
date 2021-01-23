        public RSAParameters SetPublicKey(string modulus, string exponent)
        {
            //need a dummy to create xml file for modification, you can use preloaded file
            RSAParameters dummy = new RSAParameters();
            dummy.Modulus = new byte[3];
            dummy.Exponent = new byte[256];
            RSACryptoServiceProvider crypt = new RSACryptoServiceProvider(2048);
            crypt.ImportParameters(dummy);
            
            //modify xml string with modulus and exponent
            string contents = crypt.ToXmlString(false);
            int ms = contents.IndexOf("<Modulus>");
            int me = contents.IndexOf("</Modulus>");
            contents = contents.Remove(ms + 9, me - (ms + 9));
            contents = contents.Insert((ms + 9), modulus);
            int es = contents.IndexOf("<Exponent>");
            int ee = contents.IndexOf("</Exponent>");
            contents = contents.Remove(es + 10, ee - (es + 10));
            contents = contents.Insert((es + 10), exponent);
            //import the public key
            crypt.FromXmlString(contents);
            RSAParameters result = new RSAParameters();
            result = crypt.ExportParameters(false);
            return result;
        }
