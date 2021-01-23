    var origText =
        "Type Dummy\n" +
        "Status Ready\n" +
        "# Comment line\n" +
        "# Another comment line\n" +
        "PartStatus    Result  Measurement1      Measurement2\n" +
        "900           OK      0                 20\n" +
        "600           Passed  30                400\n";
    var trimmedText = 
        Regex.Replace(origText.Substring(origText.IndexOf("PartStatus")), 
                      "[ ]+", ",");
    var csvDoc = Csv.LoadText(trimmedText, true, false, ",");
    Console.WriteLine(csvDoc.Get<int>(1, "Measurement2"));
    Console.WriteLine(csvDoc.Get<string>(0, "Result"));
