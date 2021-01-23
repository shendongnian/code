    string[] lines = File.ReadAllLines("yourInputFile.txt");
    var outputData = lines
            .Where(line => !string.IsNullOrEmpty(line)) //remove empty lines
            .OrderBy(item => item)
            .Select(line => line + Environment.NewLine); //add them back in
    File.WriteAllLines("yourOutputFile.txt", outputData.ToArray());
