    List<ProdusBon> listaProduseBon
    {
       get { return (List<ProdusBon>) Session["ProdusBon"]; }
       set { Session["ProdusBon"] = value; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (listaProduseBon == null) listaProduseBon = new List<ProdusBon>();
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        listaProduseBon.Add(new ProdusBon(-1, Int32.Parse(TextBox2.Text), -1, Int32.Parse (ListBox1.SelectedValue)));
    }
