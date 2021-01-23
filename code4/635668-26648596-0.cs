    private void groupBox5_DragDrop(object sender, DragEventArgs e)
    {
         Control c = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
         // Declare rnd globally for creating random id for dynamic button(eg : Random rnd = new Random();)
         Button btn = new Button();
         btn.Name = "Button" + rnd.Next(); 
         btn.Size = c.Size;            
         btn.Click += new System.EventHandler(DynamicButton_Click);
         if (c != null)
         {                
             btn.Text = c.Text;
             btn.Location = this.groupBox5.PointToClient(new Point(e.X, e.Y));
             this.groupBox5.Controls.Add(btn);
         }
    }
