    using(StreamReader sr = new StreamReader)
    {
    a = false;
    string line;
    while((line = sr.ReadLine()) != null)
    {
       if(line.Contains("Astring")
       a = true;
       break;
    }
    }
    file.close();
    if a = true....
