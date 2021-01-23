        public static void Test_ReadPublicKeys(PgpPublicKeyRingBundle publicKeyRingBundle)
        {
            foreach (PgpPublicKeyRing publicKeyRing in publicKeyRingBundle.GetKeyRings())
            {
                foreach (PgpPublicKey publicKey in publicKeyRing.GetPublicKeys())
                {
                    foreach (object userId in publicKey.GetUserIds())
                    {
                        Console.WriteLine(userId); //Prints "My_Key_Name (Notes) <my_email@gmail.com>"
                    }
                }
            }
        }
