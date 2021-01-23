        using (StreamReader reader =
            new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(defaultContentResourceName)))
        {
            using (StreamWriter writer = new StreamWriter(targetPath))
            {
                writer.Write(reader.ReadToEnd());
            }
        }
    
