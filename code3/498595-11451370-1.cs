    public override void Remove(object sender, ExecuteEventArgs e) 
    { 
        //Bxf.Shell.Instance.ShowError(Model.LineItems.AllowRemove.ToString(), "Delete"); 
        if(Model.LineItems.Count>0) 
            Model.LineItems.RemoveAt(0);         
    } 
