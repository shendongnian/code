       System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;
        // This is our Unicode string:
        string s_unicode = "abcéabc";
        // Convert a string to utf-8 bytes.
        byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(s_unicode);
        // Convert utf-8 bytes to a string.
        string s_unicode2 = System.Text.Encoding.UTF8.GetString(utf8Bytes);
