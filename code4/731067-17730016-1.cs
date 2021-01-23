    private const string DEFAULT_FOLDER = @"C:\TEMP";
    private const string FILE_EXTENSION = "*.xml";
    public static ICollection<ESHClass> SortedPolicies() {
      var list = new List<ESHClass>();
      var dir = new DirectoryInfo(DEFAULT_FOLDER);
      foreach (var file in dir.GetFiles(FILE_EXTENSION)) {
        using (var xmlReader = System.Xml.XmlReader.Create(file.FullName)) {
          var esh = new ESHClass() { TimeStamp = file.CreationTime };
          try {
            while (xmlReader.Read()) {
              if (xmlReader.IsStartElement()) {
                switch (xmlReader.Name) {
                  case "PolicyNumber":
                    esh.PolicyNumber = xmlReader.Value;
                    break;
                  case "PolicyMod":
                    esh.PolicyMod = xmlReader.Value;
                    break;
                  case "MultiPolicy":
                    esh.MultiPolicy = xmlReader.Value;
                    break;
                  case "HasSwimmingPool":
                    esh.HasSwimmingPool = xmlReader.Value;
                    break;
                }
              }
            }
            list.Add(esh);
          } catch (Exception err) {
            throw err;
          } finally {
            xmlReader.Close();
          }
        }
      }
      list.Sort();
      return list;
    }
