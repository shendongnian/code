    foreach (var bus in buses)
    {
        // Take ExpectedHours, or AimedHours if the first is null
        string expH = bus.ExpectedHours ?? bus.AimedHours
        // Same code as before here
        string output = expH.Substring(expH.IndexOf('T') + 1);
        int index = output.IndexOf(".");
        if (index > 0)
            output = output.Substring(0, index);
        lstHours.Items.Add(output);
    }
