    public static byte[] GetMessage(byte[] msg)
        {
            //Set delimiters
            byte delimit = 126;
            byte startDelimit = 69;
            //Reverse the msg so we can find the last packet
            List<byte> buf = msg.Reverse().ToList();
            //set indices to impossible values to check for failures
            int startIndex = -1;
            int endIndex = -1;
            //loop through the message
            for (int i = 0; i < buf.Count - 1; i++)
            {
                //find either a double 126, or 126 as the last byte (message just ended)
                if (buf[i] == delimit && (buf[i + 1] == delimit || i == 0))
                {
                    if (i == 0)
                    {
                        startIndex = i;
                        i++;
                    }
                    else
                    {
                        startIndex = i + 1;
                        i += 2;
                    }
                    continue;
                }
                //Only process if we've found the start index
                if (startIndex != -1)
                {
                    //check if the byte is 69 followed by 126
                    if (buf[i] == startDelimit && buf[i + 1] == delimit)
                    {
                        endIndex = i + 1;
                        break;
                    }
                }
            }
            //make sure we've found a message
            if (!(startIndex == -1 || endIndex==-1))
            {
                //get the message and reverse it to be the original packet
                byte[] revRet = new byte[endIndex - startIndex];
                Array.Copy(buf.ToArray(), startIndex, revRet, 0, endIndex - startIndex);
                return revRet.Reverse().ToArray();
            }
            return new byte[1];
        }
