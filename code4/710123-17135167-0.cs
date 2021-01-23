    OnClick(object sender, MouseEventArgs e)
    {
        for(int i=0; i<rects.Count; i++)
            if (r.Contains(e.Location))
                ActionForArea(i);    
    } 
