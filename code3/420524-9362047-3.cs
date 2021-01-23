    string tempFile = Path.GetTempFileName();
    using (Stream input = assembly.GetManifestResourceStream("MyPresentation.PPT"))
    using (Stream output = File.Create(tempFile))
    {
       input.CopyTo(output); // Stream.CopyTo() is new in .NET 4.0, used for simplicity and illustration purposes.
    }
