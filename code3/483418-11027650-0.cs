            DateTime now = DateTime.Now;
            long l0 = now.ToBinary();
            byte [] array = BitConverter.GetBytes(l0);
            //here you can send it to the server
            //on the server
            byte[] buffer = null;  //receive bytes 
            long l1 = BitConverter.ToInt64(buffer,0);
            DateTime time = DateTime.FromBinary(l1);
