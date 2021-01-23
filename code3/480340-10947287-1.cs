    public static void Init(Control control, Control container, Direction direction)
    {
       control.MouseDown += new System.Windows.Forms.MouseEventHandler(On_MouseDown);;
    }
    private static void On_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)       
    {     
       // Do stuff here 
    }
