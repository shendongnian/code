    private void dgv_MouseClick(object sender, MouseEventArgs e)
    {
        var ht = dgv.HitTest(e.X, e.Y);
        
        if (ht.Type == DataGridViewHitTestType.None)
        {
             //clicked on grey area
        }
    }
