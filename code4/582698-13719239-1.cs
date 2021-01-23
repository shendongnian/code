    public class Itemx
    {
        public string cod { get; set; }
        public string Tipo { get; set; }
    }
    public static List<Itemx> LItems
    {
        get
        {
            return (List<Itemx>)Session["LItems"];
        }
        set
        {
            Session["LItems"]= value;
        }
    }
    void InitializeItems()
    {
        LItems = new List<Itemx>();
        ConfigItems();
    }
    void ConfigItems()
    {
        int numitems = Convert.ToInt32(ddlNItems.SelectedValue);
        
        if (LItems.Count > numitems )
        {
            for (int i = GridView1.Rows.Count; i > numitems; i--)
            {
                LItems.RemoveAt(i - 1);
            }
        }
        else if (LItems.Count < numitems )
        {
            for (int i = GridView1.Rows.Count; i < numitems; i++)
            {
                LItems.Add(new Itemx { Tipo = "a" });
            }
        }
        transferGridtoList();
        GridView1.DataSource = LItems;
        GridView1.DataBind();
        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    private void transferGridtoList()
    {
        for (int i = 0; i < LItems.Count && i < GridView1.Rows.Count; i++)
        {
            LItems[i].cod = ((TextBox)GridView1.Rows[i].Cells[0].Controls[1]).Text;
            LItems[i].Tipo = ((DropDownList)GridView1.Rows[i].Cells[1].Controls[1]).SelectedValue;
        }
    }
    
    protected void ddlNItems_SelectedIndexChanged(object sender, EventArgs e)
    {
        ConfigItems();
    }
