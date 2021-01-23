    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.AutoGenerateColumns = false;
            GridView1.AutoGenerateEditButton = true;
            DataTable dataSource = new DataTable();
            dataSource.Columns.Add("Id", typeof(int));
            dataSource.Columns.Add("Date1", typeof(DateTime));
            dataSource.Columns.Add("Date2", typeof(DateTime));
            dataSource.Rows.Add(1, DateTime.Now, DateTime.Now.AddMonths(1));
            dataSource.Rows.Add(2, DateTime.Now.AddMonths(2), DateTime.Now.AddMonths(3));
            GridView1.Columns.Clear();
            foreach (DataColumn column in dataSource.Columns)
            {
                if (column.DataType == typeof(DateTime))
                {
                    var templateColumn = new TemplateField();
                    templateColumn.EditItemTemplate = new AddTemplateToGridView(ListItemType.EditItem, column.ColumnName);
                    templateColumn.ItemTemplate = new AddTemplateToGridView(ListItemType.Item, column.ColumnName);
                    templateColumn.HeaderText = column.ColumnName;
                    GridView1.Columns.Add(templateColumn);
                }
                else
                {
                    var dataBoundColumn = new BoundField();
                    dataBoundColumn.DataField = column.ColumnName;
                    dataBoundColumn.HeaderText = column.ColumnName;
                    GridView1.Columns.Add(dataBoundColumn);
                }
            }
            GridView1.DataSource = dataSource;
            GridView1.DataBind();
        }
        public class AddTemplateToGridView : ITemplate
        {
            ListItemType _type;
            string _colName;
            public AddTemplateToGridView(ListItemType type, string colname)
            {
                _type = type;
                _colName = colname;
            }
            public void InstantiateIn(Control container)
            {
                switch (_type)
                {
                    case ListItemType.Item:
                        Label l = new Label();
                        l.DataBinding += l_DataBinding;
                        container.Controls.Add(l);
                        break;
                    case ListItemType.EditItem:
                        Calendar calendar = new Calendar();
                        calendar.DataBinding += l_DataBinding;
                        container.Controls.Add(calendar);
                        break;
                }
            }
            void l_DataBinding(object sender, EventArgs e)
            {
                GridViewRow container;
                object dataValue;
                switch (sender.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.Label":
                        Label label = (Label)sender;
                        container = (GridViewRow)label.NamingContainer;
                        dataValue = DataBinder.Eval(container.DataItem, _colName);
                        if (dataValue != DBNull.Value)
                        {
                            label.Text = dataValue.ToString();
                        }
                        break;
                    //use the DatePickerControl.DatePicker type instead of calendar
                    case "System.Web.UI.WebControls.Calendar":
                        Calendar calendar = (Calendar)sender;
                        container = (GridViewRow)calendar.NamingContainer;
                        dataValue = DataBinder.Eval(container.DataItem, _colName);
                        if (dataValue != DBNull.Value)
                        {
                            calendar.SelectedDate = (DateTime)dataValue;
                            calendar.VisibleDate = (DateTime)dataValue;
                        }
                        break;
                }
            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataBind();
        }
    }
