    static void WriteEncryptedTextFile ( IEnumerable<string> lines , string path , byte[] key , byte[] iv , Encoding encoding )
    {
      using ( Stream             s         = File.OpenWrite(path) )
      using ( SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create() )
      using ( ICryptoTransform   transform = algorithm.CreateEncryptor( key , iv ) )
      using ( CryptoStream       cs        = new CryptoStream( s , transform , CryptoStreamMode.Write ) )
      using ( TextWriter         tw        = new StreamWriter( cs , encoding ) )
      {
        foreach ( string line in lines )
        {
          tw.WriteLine( line ) ;
        }
      }
      return ;
    }
