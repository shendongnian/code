    var buses = 
        (from tblBuses in documentRoot.Descendants(ns + "PublishedLineName")
         let bus = tblBuses.Value
         let output = bus.Substring(bus.IndexOf('T') + 1)
         let index = output.IndexOf(".")
         select (index > 0) ? output.Substring(0, index) : output);
    foreach (var bus in buses)
    {
        listBox1.Items.Add("Bus: " + bus);
    }
