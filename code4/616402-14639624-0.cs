    BitArray BAA1 = new BitArray(BitConverter.GetBytes(a1));
    BitArray BAA2 = new BitArray(BitConverter.GetBytes(a2));
    
        for (int i = r.Next(0, 64); i > 0; i--)
                {
                    temp = BAA1.Get(i);
                    temp2 = BAA2.Get(i);
    
                    BAA1.Set(i, temp2);
                    BAA2.Set(i, temp);
    
    
                    temp = BAB1.Get(i);
                    temp2 = BAB2.Get(i);
    
                    BAB1.Set(i, temp2);
                    BAB2.Set(i, temp);
                }
            byte[] tempbytes = new byte[BAA1.Length];
            BAA1.CopyTo(tempbytes, 0);
            double baa1 = BitConverter.ToDouble(tempbytes, 0);
            BAA2.CopyTo(tempbytes, 0);
            double baa2 = BitConverter.ToDouble(tempbytes, 0);
