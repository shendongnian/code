    using (StreamReader reader = new StreamReader(convertInput))
    {
        string line;
        Stringbuilder builder = new StringBuilder();
        writer.WriteLine(formatter, "Original Value", "Converted Value");
        writer.WriteLine(formatter, "--------------", "---------------");
        while ((line = reader.ReadLine()) != null)
        {
                string str2BeConverted = line;
                long numHexToDex;
                if ((Int64.TryParse(line, NumberStyles.HexNumber, null, out numHexToDec)) == false)
                {
    
                        builder.AppendLine();
                        builder.Append(line + " " + "is not a Hexadecimal value.");
                        continue; //there is ALWAYS an alternative to goto
                }
    
                Int64.TryParse(line, NumberStyles.HexNumber, null, out numHexToDec);
                string lineChanged = numHexToDec.ToString("G");
        }
    
        writer.Write(builder.ToString();
    }
