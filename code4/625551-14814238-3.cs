    public partial class MainWindow : Window 
    { 
      public MainWindow() 
      { 
        InitializeComponent(); 
      } 
      private void textBoxValue_PreviewTextInput(object sender, TextCompositionEventArgs e) 
      { 
        e.Handled = !TextBoxTextAllowed(e.Text); 
      } 
      private void textBoxValue_Pasting(object sender, DataObjectPastingEventArgs e) 
      { 
        if (e.DataObject.GetDataPresent(typeof(String))) 
        { 
          String Text1 = (String)e.DataObject.GetData(typeof(String)); 
          if (!TextBoxTextAllowed(Text1)) e.CancelCommand(); 
        } 
        else
        { 
           e.CancelCommand(); 
        }
      } 
 
      private Boolean TextBoxTextAllowed(String Text2) 
      { 
            return Array.TrueForAll<Char>(Text2.ToCharArray(), 
                delegate(Char c) { return Char.IsDigit(c) || Char.IsControl(c); }); 
      } 
    } 
