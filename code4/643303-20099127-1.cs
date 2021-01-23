    void dt_ColumnChanging(object sender, DataColumnChangeEventArgs e) {
      if (e.Column.ExtendedProperties.ContainsKey("Min") &&
          e.Column.ExtendedProperties.ContainsKey("Max")) {
        int min = (int)e.Column.ExtendedProperties["Min"];
        int max = (int)e.Column.ExtendedProperties["Max"];
        if ((int)e.ProposedValue < min) e.ProposedValue = min;
        if ((int)e.ProposedValue > max) e.ProposedValue = max;
      }
    }
