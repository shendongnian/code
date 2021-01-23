            BitArray array = new BitArray(5);
            array[0] = true;
            array[1] = false;
            array[2] = false;
            array[3] = true;
            var bytes = new byte[2];
            array.CopyTo(bytes, 0);
            Console.WriteLine((int)bytes[0]); <---- prints 9
            Console.WriteLine((int)bytes[1]); <---- prints 0
