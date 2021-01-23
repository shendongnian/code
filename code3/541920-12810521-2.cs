    public void SaveAction()
    {
            this.DBContext.SaveChanges();
			this.DBContext.Entry(this.ClientModel).State = System.Data.EntityState.Modified;
			this.sUndo.Push(this.DBContext);
			this.sRedo.Clear();
			//create a new context
			this.DBContext = DataConnection.ConnectionString.GetNewContext();
			//reload the textboxes
			ReloadData();
    }
