    public ActionResult test()
    {
         BhBuyerChart[] model = new BhBuyerChart[7];
    
         DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllShipmentRecord, CurrentUserId);
         List<BhBuyerChart> ItemList = null;
         ItemList = new List<BhBuyerChart>();
         int i = 0;
         foreach (DataRow dr in dt.Rows)
         {
             model[i] = new BhBuyerChart(dr["Shipmentdate"].ToString(), dr["ShipmentQuantity"].ToString());
             i++;
         };
    
         return View(model);
    }
    
    [HttpPost]
    public ActionResult test(ICollection<BhBuyerChart> charts)
    {
        // This allows you to POST to the controller with the modified values
    
        // Note that based on what you're collecting client side the charts
        // will ONLY contain the Quantity value, but they will all have one.
        // If you need the date you can either show a text box for that or
        // even place the date inside a hidden field.
    }
