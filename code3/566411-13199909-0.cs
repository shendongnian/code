    StringBuilder builder = new StringBuilder("Symptoms are ");
    List<string> list = new List<string>() { "headache", "corrupt memory" };
    
    foreach(var item in list)
    {
            builder.Append(item);
    }
    System.Diagnostics.Debug.WriteLine(builder.ToString());
