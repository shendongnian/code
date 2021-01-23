    // given: byte[] data = new byte[...]
    string inside = System.Convert.ToBase64String(data);
    code = string.Concat(prefix, string.Concat(inside, suffix));    
    // in your target code
    sw.Write(System.Convert.FromBase64String(inside));
