    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tx.TextChanged += new EventHandler(tx_TextChanged);
        }
    }
