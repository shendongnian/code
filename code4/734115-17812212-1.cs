    Dictionary<string, string> regions = new Dictionary<string, string>();
    string regionName = null;
    StringBuilder regionString = new StringBuilder();
    using (StreamReader streamReader = File.OpenText("MyFile.txt"))
    {
        while (!streamReader.EndOfStream)
        {
            string line = streamReader.ReadLine();
            if (line.StartsWith("--#region "))         // Beginning of the region
            {
                regionName = line.Substring(8);
            }
            else if (line.StartsWith("--#endregion"))  // End of the region
            {
                if (regionName == null)
                    throw new InvalidDataException("#endregion found without a #region.");
                regions.Add(regionName, regionString.ToString());
                regionString.Clear();
            }
            else if (regionName != null) // If the line is in a region
            {
                regionString.AppendLine(line);
            }
        }
    }
