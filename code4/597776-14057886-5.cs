    private static void DecodeFromUtf8()
    {
        string utf8_String = "dayâ€™s";
        byte[] bytes = Encoding.Default.GetBytes(utf8_String);
        utf8_String = Encoding.UTF8.GetString(bytes);
    }
