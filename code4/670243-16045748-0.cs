    static IEnumerable<string> ReadEncryptedTextFile( string path , byte[] key , byte[] iv , Encoding encoding )
    {
      string value ;
      using ( Stream s = File.OpenRead(path) )
      using ( SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create() )
      using ( ICryptoTransform transform = algorithm.CreateDecryptor( key , iv ) )
      using ( CryptoStream cs = new CryptoStream( s , transform , CryptoStreamMode.Read ) )
      using ( TextReader sr = new StreamReader(cs,encoding))
      {
          string line ;
          while ( null != ( line = sr.ReadLine() ) )
          {
              yield return line ;
          }
      }
    }
