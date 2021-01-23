    public string DotFormatToRowKey(string tempRowKey) {
    		var splits = tempRowKey.Split('.') // Split string at "."
                         .Select(x => String.Format("{0:d2}", Int32.Parse(x))) // Specify string format
                         .ToList();
    		return String.Join(String.Empty, splits.ToArray()); // Join array and return
    }
