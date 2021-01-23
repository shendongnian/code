    IDataObject data;
    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
       if (data == null) data = e.Data;            
    }
    private void Form1_DragLeave(object sender, EventArgs e)
    {
       if(ClientRectangle.Contains(PointToClient(new Point(MousePosition.X, MousePosition.Y)))){
           if (data != null)
           {
            //Process data here
            //-----------------
           }
        }
        data = null;
     }
