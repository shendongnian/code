    string name = String.Empty;
    string city = String.Empty;
    foreach (object item in userEnteredDetails)
    {
     Dictionary<string, object> details = item as  Dictionary<string, object>;
    if (details.ContainsKey("customerName"))
     name = details["customerName"] as string;
    if (details.ContainsKey("city"))
     city= details["city"] as string;
    }
