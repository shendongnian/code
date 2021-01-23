        var Info = new
        {
            TeamCode = TeamCodeTxt.Text,
            TeamName = TeamNameTxt.Text
        };
    String jsonSerializedStr=CommonUtility.SerializeJson(Info);
