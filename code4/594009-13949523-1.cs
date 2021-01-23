    public class MyUserControl : UserControl
    {
      public event EventHandler MyListBoxSelectedValueChanged;
      public object MyListBoxSelectedValue
      {
        get { return MyListBox.SelectedValue; }
      }
      public MyUserControl()
      {
        MyListBox.SelectedValueChanged += MyListBox_SelectedValueChanged;
      }
      private void MyListBox_SelectedValueChanged(object sender, EventArgs eventArgs)
      {
        EventHandler handler = MyListBoxSelectedValueChanged;
        if(handler != null)
          handler(sender, eventArgs);
      }
    }
