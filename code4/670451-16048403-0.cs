    using (var myStream = saveFileDialog1.OpenFile())
    {
        using (var writer = new CsvWriter(new StreamWriter(myStream)))
        {
            writer.Configuration.AttributeMapping(typeof(DataView)); // Creates the CSV property mapping
            writer.Configuration.Properties.RemoveAt(1); // Removes the property at the position 1
            writer.Configuration.Delimiter = "\t";
            writer.WriteHeader(typeof(DataView));
            _researchResults.ForEach(writer.WriteRecord);
        }
    }
