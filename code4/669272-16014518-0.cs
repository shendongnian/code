    bool IsPdf(string path)
    {
    	var pdfString = "%PDF-";
    	var pdfBytes = Encoding.ASCII.GetBytes(pdfString);
    	var len = pdfBytes.Length;
    	var buf = new byte[len];
    	var remaining = len;
    	var pos = 0;
    	using(var f = File.OpenRead(path))
    	{
    		while(remaining > 0)
    		{
    			var amtRead = f.Read(buf, pos, remaining);
    			if(amtRead == 0) return false;
    			remaining -= amtRead;
    			pos += amtRead;
    		}
    	}
    	return pdfBytes.SequenceEqual(buf);
    }
