    public class MyEditForm : Form
    {
      public MyEditForm( MyClass objectToDisplay )
      {
        // Suppose that you have defined databindings via the designer
        this.MyBindingSource.DataSource = objectToDisplay;
        DataBindingUtils.SuspendTwoWayBinding(this.BindingContext[MyBindingSource]);
      }
      public void btnOk_Click( object sender, EventArgs e )
      {
        DataBindingUtils.UpdateDataBoundObject(this.BindingContext[MyBindingSource]);
        this.DialogResult = DialogResult.Ok;
      }
      public void btnCancel_Click( object sender, EventArgs e )
      {
        this.DialogResult = DialogResult.Cancel;
      }
    }
    public static class DataBindingUtils
    {
      public static void SuspendTwoWayBinding( BindingManagerBase bindingManager )
      {
        if( bindingManager == null )
        {
           throw new ArgumentNullException ("bindingManager");
        }
        foreach( Binding b in bindingManager.Bindings )
        {
            b.DataSourceUpdateMode = DataSourceUpdateMode.Never;
        }
      }
      public static void UpdateDataBoundObject( BindingManagerBase bindingManager )
      {
        if( bindingManager == null )
        {
           throw new ArgumentNullException ("bindingManager");
        }
        foreach( Binding b in bindingManager.Bindings )
        {
            b.WriteValue ();
        }
      }
    }
