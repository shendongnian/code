    using System.Windows.Forms;
    
    private void onMouseMove(object sender, MouseEventArgs e)
    {
       if(sender is ListBox)
       {  
          ListBox listBox = (ListBox)sender;
          Point point = new Point(e.X, e.Y);
          int hoverIndex = listBox.IndexFromPoint(point);
          if(hoverIndex >= 0 && hoverIndex < listBox.Items.Count)
          {
             ToolTip tt = new ToolTip();
             tt.SetToolTip(listBox, "GetYourCustomTooltiphere");
          } 
       }    
    }
