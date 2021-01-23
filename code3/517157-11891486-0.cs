     DataTable appeals = new DataTable("Appeals");
     appeals.Columns["PriorAppealNumber"].Unique = true;
     DataColumn keyField = new DataColumn("AppealNumber", typeof(string));
     appeals.Columns.Add(keyField);
     
