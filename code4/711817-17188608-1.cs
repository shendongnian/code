    try
    {
            inputCharIdentifier = reader.ReadChar();
            if(inputCharIdentifier != null)
            {
    
                            switch (inputCharIdentifier)
                                 case 'A':
            
                                    field1 = reader.ReadUInt64();
                                    field2 = reader.ReadUInt64();
                                    field3 = reader.ReadChars(10);
                                    string strtmp = new string(field3);
                                    //and so on
                                    using (TextWriter writer = File.AppendText("outputA.txt"))
                                    {
                                        writer.WriteLine(field1 + "," + field2 + "," + strtmp); 
                                    }
                                    case 'B':
                                    //code...
    
           }
    }
    catch
    {
    }
