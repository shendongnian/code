    col.Visible = false; // Notice the visibility of this column...
    if (col.Visible)
    {
       // Just to be sure. Never get here.
    }
    dataGridView1.Columns.Add(col);
    if (col.Visible)
    {
       // Surprise! We are here.
    }
