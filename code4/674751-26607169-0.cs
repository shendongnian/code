    Random rnd = new Random();
    
    private void Form5_Load(object sender, EventArgs e)  
    {  
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
        // Here, you get a copy of your drag drop button and dynamically new button is created  
        Button btn = new Button();
        btn.Name = "Button" + rnd.Next();
        btn.Size = c.Size;
        if (c != null)  
        {  
            // Add the newly created button to you Panel
            btn.Location = this.panel1.PointToClient(new Point(e.X, e.Y));  
            this.panel1.Controls.Add(btn);  
        }  
    }  
    
    void panel1_DragOver(object sender, DragEventArgs e)  
    {  
        e.Effect = DragDropEffects.Move;  
    }
 
