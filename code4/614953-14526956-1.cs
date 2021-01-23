    public static List<Orders> getAllOrd()
    {
      var querry=(from o in Model.DM_Class.dc.Orders
                  join e in Model.DM_Class.dc.Employee on o.employeeID equals e.employeeID
                  select new{
                  //name all desired columns here and separate with comma 
    }).ToList();
      return querry;
