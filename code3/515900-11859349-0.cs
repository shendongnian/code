            System.Numerics.BigInteger x = System.Numerics.BigInteger.Parse("10000000000000000000000000000000000000000000000000000");
            System.Numerics.BigInteger y = System.Numerics.BigInteger.Parse("20000000000000000000000000000000000000000000000000000");
            // From BigRationalLibrary
            Numerics.BigRational r = new Numerics.BigRational(x,y);
            Console.Out.WriteLine(r.ToString());
            // outputs "1/2", but can be converted to floating point if needed.
