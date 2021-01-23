    #region [Add List Visitors]
    private void AddListVisitors(StringCollection sc)
    {
        try {
            var newVisitors = new List<List_Visitor>();
            string[] splitItems = null;
            foreach (string item in sc)
            {
                if (item.Contains(","))
                {
                    Travel_DBDataContext db = new Travel_DBDataContext();
                    splitItems = item.Split(",".ToCharArray());
                    var add_visitors = new List_Visitor();
                    add_visitors.Fullname = splitItems[0];
                    add_visitors.add = splitItems[1];
                    db.List_Visitors.InsertOnSubmit(add_visitors);
                    newVisitors.Add(add_visitors);
                }
            }    
            db.SubmitChanges();
            // Now newVisitors will contain a collection of List_Visitor
            // objects with the new Id's in.  
        }
        catch (Exception addvisitors_error) {
            Response.Write(addvisitors_error.Message + "_method addlistvisitor");
        }
    }
    #endregion
