    var participants = new List<string>();
    while (DrExistingData.Read())
    {
        participants.Add(DrExistingData["Name"].ToString());
    }
    Participant.Text = string.Join(",", participants);
