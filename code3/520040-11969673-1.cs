            for (var i = 0; i < 100; i++)
            {
                myobjects[i].ComputeHash(new byte[] { (byte)i });
                Console.WriteLine(BitConverter.ToString( myobjects[i].Hash));
            }
