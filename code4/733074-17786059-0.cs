            static void Hash2Md5inParallel()
        {
            string strFullPath = YourFilePathGoesHere;
            byte[] Buffer = new Byte[1000]; //Instantiate Buffer to copy bytes.
            byte[] DumpBuffer = new Byte[1000];  //Send output to bin.
            System.Security.Cryptography.MD5 md5_1 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            System.Security.Cryptography.MD5 md5_2 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            System.IO.FileStream file = new System.IO.FileStream(strFullPath, FileMode.Open);
            file.Seek(1000, SeekOrigin.Begin);    //skip some chars if need be
            int BytesToHash = 0;
            do
            {
                BytesToHash = file.Read(Buffer, 0, 1000);
                md5_1.TransformBlock(Buffer, 0, BytesToHash, DumpBuffer, 0);
                //enter some code to skip some bytes for the other hash if you like...
                md5_2.TransformBlock(Buffer, 0, BytesToHash, DumpBuffer, 0);
            }
            while (BytesToHash > 0); //Repeat until no more bytes.
            //call TransformFinalBlock to finish hashing - empty block is enough
            md5_1.TransformFinalBlock(new byte[0], 0, 0);
            md5_2.TransformFinalBlock(new byte[0], 0, 0);
            //Get both Hashs.
            byte[] hash1 = md5_1.Hash;
            byte[] hash2 = md5_2.Hash;
        }
