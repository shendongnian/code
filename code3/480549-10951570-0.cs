    public override void CreatePicture(Form form)
    {
        Point p1 = new Point(xx, yy);
        px.Image = img;
        px.Location = p1;
        
        form.Controls.Add(px);
        px.Show();      
    }
