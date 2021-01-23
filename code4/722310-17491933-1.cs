    Public System.Windows.Media.Brush TBBackColor
    {
       get
       {
          return (TBText.Length>160)? new SolidColorBrush(Color.Red):  new SolidColorBrush(Color.White);
       }
    }
