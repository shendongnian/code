    Function LockBoxDecrypt(Password As String, Data() As Byte) As String
        Dim AesProvider = AesCryptoServiceProvider.Create()
        Dim IV(15) As Byte, PaddedData(15) As Byte
        Array.Copy(Data, 0, IV, 0, 8)
        Array.Copy(Data, 8, PaddedData, 0, Data.Length - 8)
        AesProvider.Key = SHA1.Create().ComputeHash(Encoding.Default.GetBytes(Password)).Take(16).ToArray()
        AesProvider.IV = IV
        AesProvider.Mode = CipherMode.CFB
        AesProvider.Padding = PaddingMode.None
        Return Encoding.Default.GetString(AesProvider.CreateDecryptor().TransformFinalBlock(PaddedData, 0, PaddedData.Length), 0, Data.Length - 8)
    End Function
