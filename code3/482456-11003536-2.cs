    static class ControlFactory {
      public static Control Create(string type) {
        if ("TextBox".Equals(type))
          return new TextBox();
        
        if ("RadioButton".Equals(type)) 
          return new RadioButtonList();
      }
    }
