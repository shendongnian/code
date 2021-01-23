    List<string> attributes = new List<string>(new string[] {
        e.Company, 
        e.Name, 
        e.Address});
    attributes.RemoveAll(s => s == String.Empty);
    String.Join("-", attributes.ToArray());
