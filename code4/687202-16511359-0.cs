    using( MLMDataContext db = new MLMDataContext() )
    {
     UsersInvestement pd = new UsersInvestement();
     pd.Amount = Convert.ToDouble(Amount.Value);
     pd.UserId = Convert.ToInt32(ID.Value);
     pd.UserName = UserName.Value;
     pd.Description = "This amount has been received From LR";
     pd.IncomeTypeId = 4;
     pd.CreatedDate = DateTime.Now.Date;
     db.UsersInvestements.InsertOnSubmit(pd);
     db.SubmitChanges();
    }
