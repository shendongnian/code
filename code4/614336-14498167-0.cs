    public string Summary
    {
      get 
      {
        return String.Format(
            "{0}<strong>[{1} Devices - {2} Offline, {3} Pending </strong>",
            Name.Replace("_", " "), Total, BadCount, PendingCount);
      }
    }
