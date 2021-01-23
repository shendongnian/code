    var input = "Goi=C3=A2nia =C3=A9 badala=C3=A7=C3=A3o.";				
    var buffer = new List<byte>();
    var i = 0;
    while(i < input.Length)
    {
       	var character = input[i];
	    if(character == '=')
        {
	    	var part = input.Substring(i+1,2);
	    	buffer.Add(byte.Parse(part, System.Globalization.NumberStyles.HexNumber));
	    	i+=3;
	    }
    	else
    	{
    		buffer.Add((byte)character);
    		i++;
    	}
    };
    var output = Encoding.UTF8.GetString(buffer.ToArray());
    Console.WriteLine(output); // prints: Goiânia é badalação.
