    public class RandomService : IDisposable
    {
    	private readonly RNGCryptoServiceProvider rngCsp;
    
    	public CryptoService()
    	{
    		rngCsp = new RNGCryptoServiceProvider();            
    	}
    
    	public byte[] GetRandomBytes(int length)
    	{
    		var bytes = new byte[length];
    		rngCsp.GetBytes(bytes);
    		return bytes;
    	}
    
    	public string GetRandomString(int length)
    	{
    		var numberOfBytesForBase64 = (int) Math.Ceiling((length*3)/4.0);
    		string base64String = Convert.ToBase64String(GetRandomBytes(numberOfBytesForBase64)).Substring(0, length); //might be longer because of padding            
    		return base64String.Replace('+', '_').Replace('/', '-'); //we don't like these base64 characters
    	}
    
    	public void Dispose()
    	{
    		rngCsp.Dispose();
    	}
    }
