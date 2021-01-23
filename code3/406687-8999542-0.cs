    using (var streamReader = new StreamReader(configuration.Source))
    {
      process.StandardInput.Write(streamReader.ReadToEnd());
      process.StandardInput.Flush();
      process.StandardInput.Close();
    }
