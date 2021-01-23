    string extension = null;
    // ReSharper highlights "extension" in extension.Length with "Possible 'System.NullReferenceException'"
    if (extension.IsNotNullAndNotWhiteSpaceAnd(_ => _.Length == 3))
    {
      Console.Out.WriteLine("Length == 3");
    }
    else
    {
      Console.Out.WriteLine("Null or WhiteSpace or Length != 3");
    }
