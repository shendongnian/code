cs
public static void Main()
    {
        long count = 0;
        //byte checking sub/method
        void CheckThisBytes(byte ii, byte jj, byte kk, byte ll)
        {
            var data = new[] {ii, jj, kk, ll};
            var f = BitConverter.ToSingle(data, 0);
            //is f in range ?
            if (f >= 0.0 && f <= 1.0)
            {
                count++;
            }
        }
        const int max = 255;
        // generate all possible cases 
        for (var i = 0; i <= max; i++)
        {
            for (var j = 0; j <= max; j++)
            {
                for (var k = 0; k <=max; k++)
                {
                    for (var l = 0; l <= max; l++)
                    {
                        //check if current float is in range
                        CheckThisBytes((byte) i, (byte) j, (byte) k, (byte) l);
                    }
                }
            }
        }
        Console.WriteLine("\n Count:" + count);
        Console.ReadLine();
        //result will be  1065353218
    }
