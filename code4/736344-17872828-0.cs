    public class OrderItem
    {
       public string ProductId { get; set; }    
       public int Quantity { get; set; }
    }
    public static class OrderItemRepository()
    {
        public static List<OrderItem> GetOrderItems()
        {
            List<OrderItem> rv = new List<OrderItem>();
            rv.Add(new OrderItem{ ProductId="1", Quantity=2});
            return rv;
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
         if(!Page.IsPostBack)
         {
             //bind grid here if need be.
         }
    }
    private BindGrid()
    { 
        grdTest.DataSource = OrderItemRepository.GetOrderItems();
        grdTest.DataBind();
     }
 
    protected void btnAddItem_Click(object sender, EventArgs e)
    {
         BindGrid();
      
    }
        
