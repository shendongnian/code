         object []ar={10.20,1,1.2f,1.4,10L,12};
         using (MemoryStream ms = new MemoryStream())
         {
             foreach (dynamic t in ar)
             {
                byte[]bytes=BitConverter.GetBytes(t);
                ms.Write(bytes, 0, bytes.Length);
             }
         }
