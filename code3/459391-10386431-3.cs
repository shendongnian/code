       // Read the first 20 bytes from the stream.
       byteArray = new byte[memStream.Length];
       count = memStream.Read(byteArray, 0, 20);
       
       // Read the remaining bytes, byte by byte.
       while(count < memStream.Length)
                {
                    byteArray[count++] = 
                        Convert.ToByte(memStream.ReadByte());
                }
    
       // Decode the byte array into a char array 
       // and write it to the console.
       charArray = new char[uniEncoding.GetCharCount(
       byteArray, 0, count)];
       uniEncoding.GetDecoder().GetChars(
                    byteArray, 0, count, charArray, 0);
                Console.WriteLine(charArray); //here you should send to the file as the first example i wrote instead of to writing to console.
