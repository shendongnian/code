    public class ESHClass : IComparable<ESHClass> {
      private const string DEFAULT_FOLDER = @"C:\TEMP";
      private const string FILE_EXTENSION = "*.xml";
      public ESHClass() {
        TimeStamp = DateTime.MinValue;
      }
      public string PolicyNumber { get; set; }
      public string PolicyMod { get; set; }
      public string MultiPolicy { get; set; }
      public string HasSwimmingPool { get; set; }
      public DateTime TimeStamp { get; set; }
      public int CompareTo(ESHClass other) {
        int value = PolicyNumber.CompareTo(other.PolicyNumber);
        if (value == 0) {
          value = TimeStamp.CompareTo(other.TimeStamp);
        }
        return value;
      }
      public override string ToString() {
        return PolicyNumber;
      }
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
    }
