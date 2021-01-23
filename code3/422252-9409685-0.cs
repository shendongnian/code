    foreach( Control c in this.[immediate parent ID].Controls )
    {
        Button b = c as Button;
        if( b != null )
        {
            b.BackColor = Color.DarkGreen;
        }
    }
