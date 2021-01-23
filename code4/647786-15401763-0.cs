    public object Convert(object value, Type targetType, 
      object parameter, CultureInfo culture)
    {
      if(parameter is MessageType){
        if(((MessageType)parameter) == MessageType.Income){
          return HorizontalAlignment.Left;
        }
        else{
          return HorizontalAlignment.Right;
        }
      }
    }
