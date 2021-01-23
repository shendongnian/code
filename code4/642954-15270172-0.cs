    public partial class LeaveManagementSystemMasterPage : System.Web.UI.MasterPage
{
    SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getMenu();
        }
    }
    private void getMenu()
    {
        Connect();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string sqlQuery = "select * from menu";
        SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conn);
        da.Fill(ds);
        dt = ds.Tables[0];
        AddTopMenuItems(dt);
       
    }
    private void AddTopMenuItems(DataTable menuData)
    {
        DataView view = new DataView(menuData);
        view.RowFilter = "ParentID = 0";
        foreach (DataRowView rowView in view)
        {
            MenuItem topItem = new MenuItem(rowView["MenuName"].ToString(),rowView["MenuID"].ToString());
            Menu1.Items.Add(topItem);
            AddChildItems(menuData, topItem);
        }
    }
    private void AddChildItems(DataTable menuData, MenuItem parentMenuItem)
    {
        DataView view = new DataView(menuData);
        view.RowFilter = "ParentID = " + parentMenuItem.Value;
        foreach(DataRowView rowView in view)
        {
            MenuItem childItem = new MenuItem(rowView["MenuName"].ToString(), rowView["MenuID"].ToString());
            parentMenuItem.ChildItems.Add(childItem);
            AddChildItems(menuData, childItem);
        }
    }
    public void Connect()
    {
        string conStr="Data Source=HO-0000-LAP; Initial Catalog=LeaveManagementSystem; Integrated Security=true";
         conn = new SqlConnection(conStr);
    }
