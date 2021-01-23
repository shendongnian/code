    public void MRPCalcBtn_Click(object sender, EventArgs e)
    //Calculate MRP Report
    {
        //kick off a timer
        DateTime startTime = DateTime.Now;
    
        //Flip the panels to hide the button
        panel1.Visible = false;
        panel2.Visible = true;
        Page.Title = "MRP Report"; //set the title so we can tell if it's finished from the task bar
    
        //Create DataTable to hold items
        var dt = new DataTable();
    
        dt.Columns.Add("ItemID", System.Type.GetType("System.String"));
        dt.Columns.Add("QtyIn", System.Type.GetType("System.Decimal"));
        dt.Columns.Add("QtyOut", System.Type.GetType("System.Decimal"));
        dt.Columns.Add("DueDate", System.Type.GetType("System.DateTime"));
    
        var db = new CS3Entities(); // should these be calls to DAL?
    
        //ADD SALES ORDERS
        //---------------------------------------------------------------------------------------------
        //read orderbook in
        var orderBook = (from ob in db.SalesOrderItems
                         where ob.QtyOutstanding > 0
                         //where ob.ItemID == "9783B" //whilst testing, remove in production
                         select new { ob.ItemID, ob.QtyOutstanding, ob.DueDate });
    
        //create a queue to store temporary work, the line items are Orders
        var q1 = new Queue<OrderItem>();
    
        foreach (var item in orderBook) //loop through the order book
        {
            //Copy order book to queue to start off with
            var orderBookArray = new OrderItem
                                     {
                                         ItemID = item.ItemID,
                                         QtyIn = 0,
                                         QtyOut = item.QtyOutstanding,
                                         DueDate = item.DueDate
                                     };
    
            q1.Enqueue(orderBookArray); //adds line item to queue
        }
    
    	//determines Bill OF Materials for each item
        var billDict = (from b in db.BillOfMaterials).
                       GroupBy(b => b.ItemID).
                       ToDictionary(
                           g => g.Key, 
                           g => g.Select(b => new { b.ComponentItemID, b.Qty }).ToList()
                       );
    
        //start calculating the BoM items
        try
        {
            do //main working loop
            {
                var testItem = q1.Peek(); //pull out next line item in queue
    
                var testItemID = testItem.ItemID; //pull out ItemID from line item
                var testQty = testItem.QtyOut; //pull out Qty from line item
                var testDueDate = testItem.DueDate; //pull out ItemID from line item
     
                if (billDict.ContainsKey(testItemID)) //if line item has any sub components
                {
    				var bills = billDict[testItemID];
                    //add each sub comopnent to the queue
                    foreach (var bill in bills)
                    {
                        var bomArray = new OrderItem
                                           {
                                               ItemID = bill.ComponentItemID,
                                               QtyOut = bill.Qty*testQty,
                                               QtyIn = 0,
                                               DueDate = testDueDate
                                           };
    
                        q1.Enqueue(bomArray);
                    }
                }
                else //if no items in Bill Of Materials, must be "leaf" component, add it to "final" table
                {
                    AddToItems(dt, testItemID, 0, testQty, testDueDate); //add item to data table as QtyOut
                }
                q1.Dequeue(); //Remove item from queue
    
            } while (q1.Count != 0); //end of do loop, until queue is empty
        }
        catch
        {
            ErrorLbl.Text = "ERROR"; //if something goes wrong
        }
    
        //Queue should now be empty and DataTable dt holds all final items for purchase
    
        //ADD PURCHASE ORDERS
        //---------------------------------------------------------------------------------------------
        //read purchase orders in
        var purchaseOrderItems = (from poi in db.PurchaseOrderItems
                                  join po in db.PurchaseOrders on poi.PurchaseOrderID equals po.PurchaseOrderID
                                  where po.PurchaseOrderCancelled != true && 
                                        po.PurchaseOrderDeleted != true && 
                                        poi.Balance > 0 && 
                                        poi.LineItemComplete != true
    
                                  orderby poi.DueDate ascending 
    
                                  select new { poi.ItemID, poi.Balance, poi.DueDate }).ToList(); //Is a list faster than the database calls?
    
        foreach (var item in purchaseOrderItems) //loop through the purchase orders and append them to the temp table
        {
            //add purchase order items to data table as QtyIn
            AddToItems(dt, item.ItemID, Convert.ToDecimal(item.Balance), 0, Convert.ToDateTime(item.DueDate));
        }
    
        //SORT RESULTS
        //---------------------------------------------------------------------------------------------
        //Sort and group the raw data
        var sorteditems = //sort and group the data table to show sum of qty per day per item
            (from p in dt.AsEnumerable()
            orderby p.Field<string>("ItemID") , p.Field<DateTime>("DueDate")
            group p by new {ItemID = p.Field<string>("ItemID"), DueDate = p.Field<DateTime>("DueDate")}
            into g
    
            select new
                       {
                           g.Key.ItemID,
                           g.Key.DueDate,
                           QtyIn = g.Sum(p => p.Field<decimal>("QtyIn")),
                           QtyOut = g.Sum(p => p.Field<decimal>("QtyOut"))
                       }).ToList();
    
        //Create second DataTable to hold sorted and grouped report items
        //tried to use same datatable dt but it didn't work, no hardship to instantiate another
        var dt2 = new DataTable();
    
        dt2.Columns.Add("ItemID", Type.GetType("System.String"));
        dt2.Columns.Add("QtyIn", Type.GetType("System.Decimal"));
        dt2.Columns.Add("QtyOut", Type.GetType("System.Decimal"));
        dt2.Columns.Add("DueDate", Type.GetType("System.DateTime"));
    
        foreach (var item in sorteditems) //loop through the sorted results
        {
            //Move the sorted and grouped items into the datatable
            AddToItems(dt2, item.ItemID, Convert.ToDecimal(item.QtyIn), Convert.ToDecimal(item.QtyOut), Convert.ToDateTime(item.DueDate));
        }
    
        Session["MRPTable"] = dt2; //save datatable to session for recall later by repeater
    
        //Set repeater datasource to unique item list with details
        var itemslist = from si in sorteditems
                        group si by new { si.ItemID } into sig //equivilent to DISTINCT
    
                        join i in db.Items
                        on sig.Key.ItemID equals i.ItemID
    
                        select new
                        {
                            i.ItemID,
                            i.ItemName,
                            i.StocktakeCost,
                            i.ItemROP,
                            i.ItemROQ,
                            i.ItemUOM,
                            i.ItemStock
                        };
    
        Repeater1.DataSource = itemslist; //note repeater contains a GridView that contains the line items
        Repeater1.DataBind(); //Fire the repeater
    
        //time finished
        DateTime finishTime = DateTime.Now;
    
        //Set the start time label
        TimeStart.Text = startTime.TimeOfDay.ToString();
    
        //Set finish time
        TimeFinish.Text = finishTime.TimeOfDay.ToString();
    
        TimeTaken.Text = (finishTime - startTime).Minutes.ToString(CultureInfo.InvariantCulture) + " Minute(s), " + (finishTime - startTime).Seconds.ToString(CultureInfo.InvariantCulture) + " Seconds";
    
        //Add to activity log
        ActivityDAL.AddNewLog("MRP Report", "Generated", TimeTaken.Text, "N/A", HttpContext.Current.User.Identity.Name);
    
    }
