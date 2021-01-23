    public Consumer SelectedConsumer
    {
        get {
            if (grdConsumers.SelectedRow == null)
                return null;
            var c = new Consumer();
            c.consumerID = grdConsumers.SelectedRow.Cells[1].Text;
            c.consumerName = grdConsumers.SelectedRow.Cells[2].Text;
            c.consumerUrl = grdConsumers.SelectedRow.Cells[3].Text;
            c.consumerStatus = grdConsumers.SelectedRow.Cells[4].Text;
            return c;
        }
    }
