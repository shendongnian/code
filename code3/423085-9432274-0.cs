    using (var fileToReadFrom = File.OpenRead(@"..."))
    using (var fileToWriteTo = File.OpenWrite(@"..."))
    {
        var s = "";
        while (true)
        {
            var byteRead = fileToReadFrom.ReadByte();
            if (byteRead == -1)
                break;
            if (byteRead != '0' && byteRead != '1')
            {
                // If you want to throw on unexpected characters...
                throw new InvalidDataException(@"The file contains a character other than 0 or 1.");
                // If you want to ignore all characters except binary digits...
                continue;
            }
            s += (char) byteRead;
            if (s.Length == 8)
            {
                fileToWriteTo.WriteByte(Convert.ToByte(s, 2));
                s = "";
            }
        }
    }
