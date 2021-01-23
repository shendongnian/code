    XDocument xdoc = XDocument.Load("test.xml")
    var motions = from m in xdoc.Root.Elements("Motion")
                  select new {
                      X = (int)m.Attribute("X"),
                      Y = (int)m.Attribute("Y"),
                      Angle = (int)m.Attribute("Angle"),
                      Direction = (string)m.Attribute("Direction"),
                      File = (string)m.Attribute("file")
                  };
     foreach(var motion in motions)
     {
        // use motion
        Console.WriteLine(motion);
        // Console.WriteLine(motion.Angle);
     }
