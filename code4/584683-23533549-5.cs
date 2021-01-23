    private void callback(IntPtr buffer, int length, String filename)
    {
        try
        {
            FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write);
            UnmanagedMemoryStream ustream = new UnmanagedMemoryStream((byte*)buffer, length);
            ustream.CopyTo(file);
            ustream.Close();
            file.Close();
        }
        catch{/** To do: catch code **/}
    }
