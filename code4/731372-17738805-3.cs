    private static string[] _validExtensions;
    private static string[] ValidExtensions()
    {
        if(_validExtensions==null)
        { 
            // load from app.config, text file, DB, wherever
        }
        return _validExtensions
    }
    public static bool IsImageExtension(string ext)
    {
        return ValidExtensions().Contains(ext.ToLower());
    }
