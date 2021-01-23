    class Program
    {
    public static List<string> ChoiceExtension = new List<string>();
    static void Main()
    {
        ChoiceExtension.Add("One");
        ChoiceExtension.Add("Two");
        ChoiceExtension.Add("Three");
        //Set list as gridsource
        InserttoGrid(ChoiceExtension);
       
    }
    public static void SetDataSource(object value)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Path of Extension");
            foreach (var item in value as List<string>)
            {
                dt.Rows.Add(new object[] { item });
            }
            ExtensionList.DataSource = dt;
        }
    public static void InserttoGrid(List<string> List)
        {
            if (ChoiceExtension.Count >0)
            {
                if (this.ExtensionList.InvokeRequired)
                {
                   ExtensionList.Invoke(new SetDataSourceDelegate(SetDataSource), new Object[] { List });
                }
                else
                {
                    SetDataSource(List);
                }
            }
        }
        
    }
