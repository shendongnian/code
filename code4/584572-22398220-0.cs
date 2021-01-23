    class MyUserControl:UserControl
    {
       string strTooltip;
       public ToolTip toolTip
       {
        get;
        set;
       }
       public MyUserControl()
       {
         toolTip = new ToolTip();
         foreach(Control ctrl in this.Controls)
         {
          ctrl.MouseHover += new EventHandler(MyUserControl_MouseHover);
          ctrl.MouseLeave += new EventHandler(MyUserControl_MouseLeave);
         }
      }
      void MyUserControl_MouseLeave(object sender, EventArgs e)
      {
        toolTip.Hide(this);
      }
      void MyUserControl_MouseHover(object sender, EventArgs e)
      {
        toolTip.Show(strToolTip, this, PointToClient(MousePosition));
      }
    }
