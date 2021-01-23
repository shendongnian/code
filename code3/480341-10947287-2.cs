    public static void Init(Control control, Control container, Direction direction)
    {
       control.MouseDown += new System.Windows.Forms.MouseEventHandler(On_MouseDown);;
    }
    private static void On_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)       
    {     
       Control control = sender as Control;
       if(control != null){
           // Here we go, use the control to do whatever you want with it 
       } 
    }
