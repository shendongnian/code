    public void setApproval(string approvalCode, int ID)
    {
        using (DatabaseDataContext context = new DatabaseDataContext(DBConnection().getConnectionString()))
        {
            myRecord con = context.TableName.First(item => item.ID == ID); //Gets the record succesfully, PK field in tact
            con.ApprovalStatus = approvalCode;
    
            context.SubmitChanges();
        }
    }
