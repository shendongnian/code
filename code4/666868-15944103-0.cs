    public class Decrypter
    {
    	private MemoryStream msDecrypt;
    	private CryptoStream csDecrypt;
    	
    	public Decrypter(ICryptoTransform decryptor)
    	{
    		msDecrypt = new MemoryStream();
    		csDecrypt = new CryptoStream(msDecrypt,decryptor,CryptoStreamMode.Write);
    	}
    	
    	public byte[] DecryptUsingDecryptor(byte[] dataToDecrypt)
    	{
    		byte[] decryptedData = null;
    		
    		csDecrypt.Write(dataToDecrypt, 0, dataToDecrypt.Length);
    		csDecrypt.FlushFinalBlock();
    		decryptedData = msDecrypt.ToArray();
    		csDecrypt.Close();
    		return decryptedData;
    	}
    }
