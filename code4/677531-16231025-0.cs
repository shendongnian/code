    var builder = new StringBuilder();
    if(DrExistingData.Read()) {
        builder.Append(DrExistingData.GetString("Name"));
        while(DrExistingData.Read()) {
            builder.Append(',').Append(DrExistingData.GetString("Name"));
        }
    }
    Participant.Text = builder.ToString();
