    string ResxFile = System.IO.File.ReadAllText("Properties/Resources.resx");
    string wordResxName = resxname;
    string word = resxvalue;
    string ResxAddStrings = "  <data name=\"" + wordResxName + "\" xml:space=\"preserve\">\r\n    <value>" + word + "</value>\r\n  </data>\r\n";
    ResxAddStrings += "</root>";
    System.IO.File.WriteAllText("Properties/Resources.resx", ResxFile);
