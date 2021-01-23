    String Dist, Cals;
    
    bool distParsed = Double.TryParse(distance,out Dist);
    bool calsParsed = Double.TryParse(calories,out Cals);
    
    if(!distParsed||!calseParsed)
    {
      String message = !distParsed ? "Distance failed to parse" : "";
      if(message.Trim().Length==0)
        message = !calsParsed ? "Calories failed to parse" : "";
      MessageBox.Show(message);
    }
