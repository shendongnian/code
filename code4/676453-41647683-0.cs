    public void launchExcel()
    {
        String resourceName = "Sample.xls";
        String path = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    
    
        Assembly asm = Assembly.GetExecutingAssembly();
        string res = string.Format("{0}.Resources." + resourceName, asm.GetName().Name);
        Stream stream = asm.GetManifestResourceStream(res);
        try
        {
            using (Stream file = File.Create(path + @"\" + resourceName))
            {
                CopyStream(stream, file);
            }
            Process.Start(path + @"\" + resourceName);
        }catch (IOException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    
    public void CopyStream(Stream input, Stream output)
    {
        byte[] buffer = new byte[8 * 1024];
        int len;
        while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            output.Write(buffer, 0, len);
        }
    }
