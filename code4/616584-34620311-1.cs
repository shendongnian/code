    SslStream sslStream = new SslStream(client.GetStream(), false,
        new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
    ....
    public static bool ValidateServerCertificate(object sender,
                                                 X509Certificate certificate,
                                                 X509Chain chain,
                                                 SslPolicyErrors sslPolicyErrors)
    {
      if (sslPolicyErrors == SslPolicyErrors.None)
        return true;
      gerarLog("Certificate error: " + sslPolicyErrors);
      // Do not allow this client to communicate with unauthenticated servers.
      return false;
    }
    public static byte[] HexStringToByteArray(string hexString)
    {
      byte[] HexAsBytes = new byte[hexString.Length / 2];
      for (int index = 0; index < HexAsBytes.Length; index++)
      {
        string byteValue = hexString.Substring(index * 2, 2);
        HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
      }
      return HexAsBytes;
    }
