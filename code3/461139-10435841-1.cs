    public MainWindow()
    {
       InitializeComponent();
     
       byte[] encryptedPassword;
     
       // Create a new instance of the RijndaelManaged
       // class.  This generates a new key and initialization 
       // vector (IV).
       using (var algorithm = new RijndaelManaged())
       {
          algorithm.KeySize = 256;
          algorithm.BlockSize = 128;
     
          // Encrypt the string to an array of bytes.
          encryptedPassword = Cryptology.EncryptStringToBytes("Password", 
                                                        algorithm.Key, algorithm.IV);
       }
     
       string chars = encryptedPassword.Aggregate(string.Empty, 
                                             (current, b) => current + b.ToString());
     
       Cryptology.EncryptFile(@"test.txt", @"encrypted_test.txt", chars);
     
       Cryptology.DecryptFile(@"encrypted_test.txt", "unencyrpted_test.txt", chars);
    }
