    private string _bgColor;
      public string bgColor
      {
         get
         {
            if (string.IsNullOrEmpty(_bgColor))
            {
               _bgColor = "FFFFFF";
            }
            
            return _bgColor;
         }
         set { _bgColor = value; }
      }
 
