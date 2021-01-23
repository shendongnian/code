    if (!File.Exists(filesName)) {
        string header = "NE,Alarm,Occurrence,Clearance,CabinetNo,SubrackNo,SlotNo,PortNo,BoardType,SiteNo,SiteType,SiteName";
        File.AppendAllText(filesName, header + Environment.NewLine);
    }
    string line = textBoxAlarm.Text.TrimEnd(' ', '.');
    string[] values = Regex.Split(line, @",?\s*\w+(\sNo\.|\sType|\sName)?=",
                                  RegexOptions.ExplicitCapture);
    List<string> valuesList = values.ToList();
    valuesList.RemoveAt(5); // Remove the empty Details part.
    valuesList.RemoveAt(0); // Remove the first empty part.
    values = valuesList
        .Select(s => s == "" ? "********" : s)
        .ToArray();
    File.AppendAllText(filesName, String.Join(",", values) + Environment.NewLine);
