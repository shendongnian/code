    void DisplayValues(OrderedDictionary newValues, OrderedDictionary oldValues)
      {
    
        Message.Text += "<br/></br>";
    
        // Iterate through the new and old values. Display the
        // values on the page.
        for (int i = 0; i < oldValues.Count; i++)
        {
          Message.Text += "Old Value=" + oldValues[i].ToString() +
            ", New Value=" + newValues[i].ToString() + "<br/>";
        }
    
        Message.Text += "</br>";
    
      }
