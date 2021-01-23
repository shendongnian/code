    public static string ReadWord(this StreamReader stream, Encoding encoding)
    {
    	string word = "";
    	while(stream.Read().With(c => {
    		var chr = encoding.GetChars(BitConverter.GetBytes(c)).First();
    		if (c == -1 || Char.IsWhiteSpace(chr))
    			return -1;
    		else
    			word = word + chr;
    		return c;
    	}) > -1);
    	return word;
    }
    
    public static T With<T>(this T obj, Func<T,T> f)
    {
    	return f(obj);
    }
