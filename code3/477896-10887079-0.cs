      public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Form.Controls.Add(AddToList()); 
        }
       public static HtmlGenericControl AddToList()      
       {
           HtmlGenericControl menu = new HtmlGenericControl("ul");
           DataTable table = GetMenus();
           //NOTE  i initialized this to 7, because this is the max rows id, and
           // im basing my builder on indexes to work. This can be easily replaced to
           // a dictionary<int,HtmlGenericControl> or any othre suitable collection
           HtmlGenericControl[] arrayOfLists = new HtmlGenericControl[7];
           foreach (DataRow row in table.Rows)
           {
              //assume control has no children, unless proved otherwise
               HtmlGenericControl temp  = new HtmlGenericControl("li");
               //add the control to its indexes place in the array and init it
               arrayOfLists[(int)row["id"] - 1] = temp;
               HtmlAnchor link = new HtmlAnchor();
               link.HRef = row["url"].ToString();
               link.InnerText = row["menuname"].ToString();
               temp.Controls.Add(link);
               int? parentId = string.IsNullOrEmpty(row["parentmenuId"].ToString()) ? null : (int?)int.Parse(row["parentmenuId"].ToString());
               if (parentId.HasValue)
               {
                   // if a control has a parent - make its parent a ul insead of li
                  // and add it to the parents collection
                   arrayOfLists[parentId.Value - 1].TagName = "ul";
                   arrayOfLists[parentId.Value - 1].Controls.Add(arrayOfLists[(int)row["id"] - 1]);
               }
               else
               {
                    // no parent = add to the first created ul menu
                   menu.Controls.Add(temp);
               }
               
           }
      
           return menu;     
       }
        
       public static DataTable GetMenus()
       {
           DataTable dt = new DataTable ();
           dt.Columns.Add("id", typeof(int));
           dt.Columns.Add("menuname", typeof(string));
           dt.Columns.Add("url", typeof(string));
           dt.Columns.Add("parentmenuId", typeof(string));
           dt.Rows.Add(1,"Home","~/Home.aspx",        null  );
           dt.Rows.Add( 2,"Product","~/products.aspx",    null);
           dt.Rows.Add(3,"services", "~/services.aspx",null);
           dt.Rows.Add(4, "ERP",  "~/erp.aspx",           "2" );
           dt.Rows.Add( 5  ,"HRM" ,"~/hrm.aspx",           "4" );
           dt.Rows.Add(7, " Payroll", "~/payroll.aspx", "4");
           return dt;
            
       }
