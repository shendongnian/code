    public class MyDialog : Form
    {
        // We can make the constructor private, as this class is instantiated only
        // in the Show method.
        private MyDialog()
        {
        }
        // ...
        public class ReturnValue
        {
            public string Foo { get; set; }
            // ...
        }
        public static ReturnValue ShowModal(/* any params, if required */)
        {
            ReturnValue result;
            MyDialog dialog = null;
            if(DialogResult.OK == dialog.ShowDialog(null))
            {
                result = new MyDialog();
                result.Foo = dialog.txtFoo.Text;
                // ...
            }
            return result;
        }
    }
