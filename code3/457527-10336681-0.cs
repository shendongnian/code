    using (var reader = File.OpenText(originalFile))
    using (var writer = File.CreateText(tempFile))
    {
        string line;
        while ((line = reader.ReadLine()) != null) 
        {
            var temp = DoMyStuff(line);
            writer.WriteLine(temp);
        }
    }
    File.Delete(originalFile);
    File.Move(tempFile, originalFile);
