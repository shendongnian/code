    select new
    {
       OrderID = (int) item.Element("OrderID"),
       POnumber = (int) item.Element("PurchaseNumber"),
       OrderDate = (DateTime) item.Element("DatePurchased"),
       Source = (string) item.Element("HearedAbout") ?? ""
    }
