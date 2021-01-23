    @Html.DevExpress().GridView(...).BindToLINQ("", "", (s, e) => { 
        e.KeyExpression = "row_id";
    	
    	DBEntities dbEntities = new DBEntities();
        var myLinqQuery = from s in dbEntities.myTable select new { s.row_id, s.row_username };
    	
    	e.QueryableSource = myLinqQuery; 
    }).GetHtml()
