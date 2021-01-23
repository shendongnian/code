    public delegate event DataChangedHandler(object sender, SuperEventArgs e);
    public class Simple1 {
      private object parameter1, parameter2;
      private Control parent;
      #if PocketPC
      public delegate void MethodInvoker(); // include this if it is not defined
      #endif
      public Simple1(Control frmControl, object param1, object param2) {
        parent = frmControl;
        parameter1 = param1;
        parameter2 = param2;
      }
      public event DataChangedHandler DataChanged;
        
      public void Start() {
        object myData = new object(); // whatever this is. DataTable?
        try {
          // long routine code goes here
        } finally {
          if (DataChanged != null) {
            SuperEventArgs e = new SuperEventArgs(myData);
            MethodInvoker methInvoker = delegate {
              DataChanged(this, e);
            };
            try {
              parent.BeginInvoke(methInvoker);
            } catch (Exception err) {
              Log(err); // something you'd write
            }
          }
        }
      }
        
    }
