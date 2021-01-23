            System.Numerics.BigInteger a;
            System.Numerics.BigInteger.TryParse("00010471000001BF001F", System.Globalization.NumberStyles.HexNumber,null,out a);
            Console.WriteLine(a.ToString());
            System.Numerics.BigInteger.TryParse("00010471000001BF0021", System.Globalization.NumberStyles.HexNumber, null, out a);
            Console.WriteLine(a.ToString());
