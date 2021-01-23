    private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
    {
      if (e.ChangedItem.Label == "MyCountry")
      {
        if(e.ChangedItem.Value != e.OldValue)
          m.MyCity = "";
      }
    }
