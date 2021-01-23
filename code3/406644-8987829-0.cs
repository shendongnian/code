    dt.AsEnumerable().Where(row => row.IsNull("name")).Select((row, index) =>
    {
        System.Diagnostics.Debug.WriteLine("Name in Row # " + index + " is null.");
        row["Status"] = "Disabled";
        return true;
    });
