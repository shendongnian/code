    ArrayList list = t.DepartureCities;
    StringBuilder builder = new StringBuilder();
    for (int i = 0; i < list.Count; i++) {
    
      if (builder.Length > 0) {
        builder.Append(", ");
      }
      object current = list[i];
      builder.Append(current);
    }
    lblDeparture.Text = builder.ToString();
