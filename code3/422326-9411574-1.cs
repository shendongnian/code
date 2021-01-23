      var phase = new Phase();
      phase.Min = new double[2];
      phase.Max = new double[2];
    
      var serializer = new XmlSerializer(typeof(Phase));
      var sw = new StringWriter();
      serializer.Serialize(sw, phase);
      Console.WriteLine(sw.ToString());
