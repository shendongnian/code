    using (var input = File.OpenRead(fromFile))
    {
      using (var output = File.OpenWrite(toFile))
      {
        input.CopyTo(output);
      }
    }
