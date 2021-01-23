    class MyPanel : FlowLayoutPanel
    {
         public MyPanel()
    
         {
            this.BackColor = Color.Red;
            this.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
    
            listBox = new ListBox();
    
            this.WrapContents = false;  // Use this for control not wrapped
            editButton = new Button();
           
    
            this.Controls.Add(listBox);
            this.Controls.Add(editButton);
         }
     }
