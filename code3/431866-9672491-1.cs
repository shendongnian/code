    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<Order> List = new List<Order>();
    
            Order OrderObj = new Order();
            Order.CourceFeeType Fees = new Order.CourceFeeType();
            Fees.Code = "1";
            Fees.Desc = "w2s";
            OrderObj.Amount = 1;
            OrderObj.AddFeeTypeDetails(Fees);
    
            List.Add(OrderObj);
    
            OrderObj = new Order();
            OrderObj.Amount = 2;
            Fees = new Order.CourceFeeType();
            Fees.Code = "2";
            Fees.Desc = "w22s";
            OrderObj.AddFeeTypeDetails(Fees);
    
            List.Add(OrderObj);
    
            rpt.DataSource = List;
            rpt.DataBind();
        }
    
    }
