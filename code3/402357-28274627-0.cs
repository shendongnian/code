    private string GetMD5()
    {
    	System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
    	System.IO.FileStream stream = new System.IO.FileStream(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
    
    	md5.ComputeHash(stream);
    
    	stream.Close();
    
    	System.Text.StringBuilder sb = new System.Text.StringBuilder();
    	for (int i = 0; i < md5.Hash.Length; i++)
    		sb.Append(md5.Hash[i].ToString("x2"));
    
    	return sb.ToString().ToUpperInvariant();
    }
