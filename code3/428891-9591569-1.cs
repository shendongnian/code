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
            ReturnValue result = new ReturnValue();
            MyDialog dialog = new MyDialog();
            if(DialogResult.OK == dialog.ShowDialog(null))
            {
                // We can access private members like txtFoo since we are within the class.
                result.Foo = dialog.txtFoo.Text;
                // ...
            }
            return result;
        }
    }
