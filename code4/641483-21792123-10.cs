    public static string ReadWord(this StreamReader stream, Encoding encoding)
    {
    	string word = "";
        // read single character at a time building a word 
        // until reaching whitespace or (-1)
    	while(stream.Read()
           .With(c => { // with each character . . .
                // convert read bytes to char
                var chr = encoding.GetChars(BitConverter.GetBytes(c)).First();
                if (c == -1 || Char.IsWhiteSpace(chr))
                     return -1; //signal end of word
                else
                     word = word + chr; //append the char to our word
                return c;
    	}) > -1);  // end while(stream.Read() if char returned is -1
    	return word;
    }
    
    public static T With<T>(this T obj, Func<T,T> f)
    {
    	return f(obj);
    }
