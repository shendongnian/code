            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(Properties.Resources.RSAParameters);
            
            RSAParameters par = rsa.ExportParameters(true); // export the private key
            
            using (OpenSSL.Crypto.RSA rsaos = new OpenSSL.Crypto.RSA())
            using (BigNumber bnmod = BigNumber.FromArray(par.Modulus))
            using (BigNumber bnexp = BigNumber.FromArray(par.Exponent))
            using (BigNumber bnD = BigNumber.FromArray(par.D))
            using (BigNumber bnP = BigNumber.FromArray(par.P))
            using (BigNumber bnQ = BigNumber.FromArray(par.Q))
            using (BigNumber bnDmodP = BigNumber.FromArray(par.DP))
            using (BigNumber bnDmodQ = BigNumber.FromArray(par.DQ))
            using (BigNumber bnInverse = BigNumber.FromArray(par.InverseQ))
            {
                rsaos.PublicExponent = bnexp;
                rsaos.PublicModulus = bnmod;
                rsaos.IQmodP = bnInverse;
                rsaos.DmodP1 = bnDmodP;
                rsaos.DmodQ1 = bnDmodQ;
                rsaos.SecretPrimeFactorP = bnP;
                rsaos.SecretPrimeFactorQ = bnQ;
                rsaos.PrivateExponent = bnD;
                string privatekey = rsaos.PrivateKeyAsPEM;   
                string publickey = rsaos.PublicKeyAsPEM
            }
