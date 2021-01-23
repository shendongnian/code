    private void WriteFileCommandExecuted(string FirmwarePath)
 
           {//you can pass the file path any way you like
       if(Firmwarepath == null)
                 return;
            System.IO.FileStream fs = new System.IO.FileStream(FirmwarePath, System.IO.FileMode.OpenOrCreate);
            System.IO.StreamReader sr = new System.IO.StreamReader(fs);
           
            string data = sr.ReadToEnd();
            char[] buff = data.ToArray<char>(); //No unsigned char in c# you could choose to //use byte data type which is unsigned
            int size = buff.Length; //This gives you the number of elements in the buffer (number of characters) NOT the size of the array in memory (char is unicode so it is 2 bytes)
        }
