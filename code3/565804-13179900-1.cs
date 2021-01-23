    try
    {
             this.SortedLaneConfigs[i].CheckConsistency();
    }
    catch (Exception e)
    {
            exBuilder.Append("Error message below: \n\"" + String.Format("Configs #{0} NOT consistent : {1}", SortedLaneConfigs[i].Id, e.Message) + "\"");
            exBuilder.Append(Environment.NewLine);
    }
