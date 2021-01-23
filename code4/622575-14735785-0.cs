          namespace WpfApplication1
          {
             public  class myCustomCommand.
              {
                   private static RoutedUICommand _luanchcommand;//mvvm
                     static myCustomCommand.()
                      {
                   System.Windows.MessageBox.Show("from contructor"); // static consructor is                                                 called when static memeber is first accessed(non intanciated object)
           InputGestureCollection gesturecollection = new InputGestureCollection();
           gesturecollection.Add(new KeyGesture(Key.L,ModifierKeys.Control));//ctrl+L
           _luanchcommand =new RoutedUICommand("Launch","Launch",typeof(myCustomCommand.),gesturecollection);
       }
       public static  RoutedUICommand Launch
       {
           get
           {
               return _luanchcommand;
           }
       }
    }
       }
