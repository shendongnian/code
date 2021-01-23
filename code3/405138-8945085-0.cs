     byte[] byteArray = Encoding.ASCII.GetBytes(preStream);
     long pad = (minBlobEntrySize * databaseCount) - byteArray.Length;
     Array.Copy(byteArray, 0, buffer, relativeOffset2, byteArray.Length);
     byte[] padBuff = new byte[pad]; //will be zeros...
     Array.Copy(padBuff, 0, buffer, relativeOffset2 + byteArray.Length, pad);
