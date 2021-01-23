    int N = 2; // assuming TOP 2
    var statuses = doc.Descendants("Action")
                      .Where(s => s.Element("ContractID").Value.Equals("2"))
                      .Select(s => s.Element("Status").Value)
                      .Take(N);
