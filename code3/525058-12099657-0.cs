    MyClass()
    {
         // create the context menu in the constructor:
         this.ContextMenu = new System.Windows.Controls.ContextMenu();   
         System.Windows.Controls.MenuItem item1 = new System.Windows.Controls.MenuItem();
         item1.Header = "A new Test";
         this.ContextMenu.Items.Add(item1);
    }
    private void mouseClickedResponse(object sender, System.Windows.Input.MouseEventArgs e)
    {
        if (e.RightButton == MouseButtonState.Pressed)
        {
              // show the context menu as soon as the right mouse button is pressed
              this.ContextMenu.Show(this, e.Location);
        }
    }
