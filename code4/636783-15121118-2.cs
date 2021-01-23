        List<TLong> num = new List<TLong>();
        int i = 0;
        while (p * i < a.Length)
        {
            TLong y = 0;
            //transform from base-10 to base-K in chunks of p elements
            for (int j = p * i; j < Math.Min(p * (i + 1), a.Length); j++)
                y = y * K + a[j];
            
            num.Add(sum);
            i++;
        }
        TLong[] result = num.ToArray();
