    static char ReadChar = 'a';
    static bool ReadSuccess = false;
    static void TryReading(object callback)
    {
        int read = reader.Read();
        ReadChar = (char)read;
        ReadSuccess = true;
    }
