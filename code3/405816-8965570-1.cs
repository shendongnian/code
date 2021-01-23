    public class SelectedOrder
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }
    // Then in your ListView ItemCommand in Page1.aspx
    var orders = ((List<SelectedOrder>)Session["Order"]) ?? new List<SelectedOrder>();
    orders.Add(new SelectedOrder() { ID = id, Value = value });
    Session["Order"] = orders;
    // And in Page2
    List<SelectedOrder> orders = (List<SelectedOrder>)Session["Order"];
    if (null != orders) {
        GridView1.DataSource = orders;
        GridView1.DataBind();
        // Rest of code follows...
    }
