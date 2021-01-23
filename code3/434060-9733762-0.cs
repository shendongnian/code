    private void missionsBox_DragDrop(object sender, DragEventArgs e)
    {
        Point point = missionsBox.PointToClient(new Point(e.X, e.Y));
        int index = missionsBox.IndexFromPoint(point);
        object data = e.Data.GetData(typeof(string));
        missionsBox.Items.Remove(data);
        missionsBox.Items.Insert(index, data);
        
        //try this?
        missionsBox.Items[index + 1].Selected = True;
    
    }
