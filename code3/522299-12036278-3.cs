    string extension = null;     //Test for null
    //string extension = "123";  //Test for Length==3
    if (extension.IsNotNullAndNotWhiteSpaceAnd(_ => _.Length == 3))
    {
      Console.Out.WriteLine("Length == 3");
    }
    else
    {
      Console.Out.WriteLine("Null or WhiteSpace or Length != 3");
    }
