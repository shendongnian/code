    if (dt.Equals(e.Day.Date))
    {
      strEvents.Append("bingo</a>");
      e.Cell.Controls.Add(new LiteralControl("<br>" + strEvents.ToString()));
      //for example what if the event were holiday it would be 
      //e.Cell.Controls.Add(new LiteralControl("<br>Holiday")); does this make sense
    } 
