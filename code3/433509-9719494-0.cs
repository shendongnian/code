    foreach (char c in str)
    {
        if ((int)c < 256)
            Console.Write(c);
        else
            Console.Write(String.Format("\\u{0:x4}", (int)c));
    }
;)
