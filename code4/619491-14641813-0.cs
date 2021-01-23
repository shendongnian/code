    var properties = typeof(YourModel).GetProperties();
    string headerLine = string.Join(",",
                    typeof(YourModel).GetProperties().Select(p => p.Name));
    var dataLines = yourModellist.Select(item =>
                string.Join(",", properties.Select(p => p.GetValue(item, null))));
    var allLines = new[] { headerLine }.Concat(dataLines);
    File.WriteAllLines("your csv file", allLines);
