    using System.Windows.Forms;
    // reference System.Drawing
    //
    Screen s = Screen.AllScreens()[1];
    System.Drawing.Rectangle r  = s.WorkingArea();
    Me.Top = r.Top;
    Me.Left = r.Left;
