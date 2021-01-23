    public Status InsertStatus(Status status, int userID)
    {
        using (var db = new ERPDataContext())
        {
            status.CreatedBy = userID;
            status.Created = DateTime.Now;
            db.Status.InsertOnSubmit(status);
            db.SubmitChanges();
            return status;
        }
    }
    private void Add_Status()
    {
        using (var db = new ERP_ServiceClient())
        {
            var status = new Erp_ServiceReference.Status();
            status.Name = this.txtStatusNameAdd.Text;
            status = db.InsertStatus(status, this.IdUser);
            statusBindingSource.Add(status);
        }
    
        this.txtStatusNameAdd.Text = "";
        this.txtStatusNameAdd.Select();
    }
