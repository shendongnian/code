    string ReadLine( Stream sr,bool goToNext)
    		{            
                if (sr.Position >= sr.Length)
                    return string.Empty;            
                char readKey;
                StringBuilder strb = new StringBuilder();
                long position = sr.Position;
                do
                {
                    readKey = (char)sr.ReadByte();
                    strb.Append(readKey);
                }
    			while (readKey != (char)ConsoleKey.Enter && sr.Position<sr.Length);
                if(!goToNext)
                sr.Position = position;
                return strb.ToString();        
            }
