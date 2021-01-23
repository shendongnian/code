    var arrays = new List<byte[]>();
    using (var f = new FileStream("test.txt", FileMode.Open))
    {
        for (int i = 0; i < f.Length; i += 4)
        {
            var b = new byte[4];
            var bytesRead = f.Read(b, i, 4);
            if (bytesRead < 4)
            {
                var b2 = new byte[bytesRead];
                Array.Copy(b, b2, bytesRead);
                arrays.Add(b2);
            }
            else if (bytesRead > 0)
                arrays.Add(b);
        }
    }
    //make changes to arrays
    using (var f = new FileStream("test-out.txt", FileMode.Create))
    {
        foreach (var b in arrays)
            f.Write(b, 0, b.Length);
    }
