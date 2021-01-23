    public class MyForm : Form
    {
      public MyForm()
      {
        MyUserControl.MyListBoxSelectedValueChanged += MyUserControl_MyListBoxSelectedValueChanged;
      }
      private void MyUserControl_MyListBoxSelectedValueChanged(object sender, EventArgs eventArgs)
      {
        object selected = MyUserControl.MyListBoxSelectedValue;
      }
    }
