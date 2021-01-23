    public static string ReadLineAndCountPosition(this FileStream fs, ref long position)
    {
        bool is_carriage_return = false;
        StringBuilder sb = new StringBuilder();
        fs.Seek(position, SeekOrigin.Begin);
    
        while (true)
        {
            position++;
            var my_byte = fs.ReadByte();
    
            //Check for newlines
            if (is_carriage_return && my_byte == 10)// \n
                return sb.ToString();
            if (my_byte == 13)                     // \r
                is_carriage_return = true;
            else
            {
                is_carriage_return = false;
                sb.Append((char)my_byte);
            }
        }
    }
