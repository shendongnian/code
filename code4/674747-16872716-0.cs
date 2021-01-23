      this.panel1.AllowDrop = true;  
            foreach (Control c in this.panel1.Controls)  
            {  
                c.MouseDown += new MouseEventHandler(c_MouseDown);  
            }  
            this.panel1.DragOver += new DragEventHandler(panel1_DragOver);  
            this.panel1.DragDrop += new DragEventHandler(panel1_DragDrop);  
        }  
 
        void c_MouseDown(object sender, MouseEventArgs e)  
        {  
            Control c = sender as Control;  
            c.DoDragDrop(c, DragDropEffects.Move);  
        }  
 
        void panel1_DragDrop(object sender, DragEventArgs e)  
        {  
            Control c = e.Data.GetData(e.Data.GetFormats()[0]) as Control;  
            if (c != null)  
            {  
                c.Location = this.panel1.PointToClient(new Point(e.X, e.Y));  
                this.panel1.Controls.Add(c);  
            }  
        }  
 
        void panel1_DragOver(object sender, DragEventArgs e)  
        {  
            e.Effect = DragDropEffects.Move;  
        }  
       
