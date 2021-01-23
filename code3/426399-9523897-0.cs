    public enum EncodingType 
    { 
        ASCII, 
        Unicode, 
        UTF7, 
        UTF8 
    } 
    public static string ByteArrayToString(byte[] bytes) 
    { 
        return ByteArrayToString(bytes, EncodingType.Unicode); 
    } 
    public static string ByteArrayToString(byte[] bytes, EncodingType encodingType) 
    { 
        System.Text.Encoding encoding=null; 
        switch (encodingType) 
        { 
        case EncodingType.ASCII: 
            encoding=new System.Text.ASCIIEncoding(); 
            break;    
        case EncodingType.Unicode: 
            encoding=new System.Text.UnicodeEncoding(); 
            break;    
        case EncodingType.UTF7: 
            encoding=new System.Text.UTF7Encoding(); 
            break;    
        case EncodingType.UTF8: 
            encoding=new System.Text.UTF8Encoding(); 
            break;    
        } 
        return encoding.GetString(bytes); 
    } 
