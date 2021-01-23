    private Stack<DatabaseContainer> sUndo;
    private Stack<DatabaseContainer> sRedo;
    public void Undo()
    {
			if (this.sUndo.Count == 0) return;
			//push the current context onto the redo queue
            this.DBContext.Entry(this.ClientModel).State = System.Data.EntityState.Modified;
			this.sRedo.Push(this.DBContext);
			//make the last context the current context
			this.DBContext = this.sUndo.Pop();
            //Save this context's modifications to the database
			this.DBContext.SaveChanges();
			//reload the textboxes on the form with what is in the newest DBContext 
            //(so the bindings are bound to this context)
			ReloadData();
    }
