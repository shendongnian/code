    Encoding dosEncoding = Encoding.GetEncoding(437);
    string original = String.Empty;
    
    using (StreamReader sr = new StreamReader(@"D:\Path\To\output.csv", dosEncoding))
    {
    	original = sr.ReadToEnd();
    	sr.Close();
    }
    	
    byte[] encBytes = dosEncoding.GetBytes(original);
    byte[] utf8Bytes = Encoding.Convert(dosEncoding, Encoding.UTF8, encBytes);
    
    string converted = Encoding.UTF8.GetString(utf8Bytes);
