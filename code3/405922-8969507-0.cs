    public static bool WriteFile(ByteBuffer data, String fileName, bool append)
    {
        using(var writer = new StreamWriter(fileName, append))
        {
            try
            {
                writer.Write(data);
                return true;
            }
            catch (Exception ex)
            {
                // log the exception details; don't just eat it.
            }
        }
        return false;
    }
