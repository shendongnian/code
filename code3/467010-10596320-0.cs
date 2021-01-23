    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<string> Listtags = GetListTag.GetTagList().ToList();
            Listtags.ForEach(t => BulletedList1.Items.Add(t));
        }
    }
