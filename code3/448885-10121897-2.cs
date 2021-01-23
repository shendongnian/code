    public class GridViewCheckBoxTemplate : ITemplate
    {
        ListItemType _templateType;
        string _columnName;
    
        public GridViewCheckBoxTemplate(ListItemType type, string colname)
        {
            _templateType = type;
            _columnName = colname;
        }
    
        void ITemplate.InstantiateIn(System.Web.UI.Control container)
        {
            switch (_templateType)
            {
                case ListItemType.Header:
                   break;
                case ListItemType.Item:
                    var chb1 = new CheckBox();
                    chb1.DataBinding += new EventHandler(CB_DataBinding);
                    container.Controls.Add(chb1);
                    break;
                case ListItemType.EditItem:
                    //As, I am not using any EditItem, I didnot added any code here.
                    break;
                case ListItemType.Footer:
                    break;
            }
        }
    
        void CB_DataBinding(object sender, EventArgs e)
        {
            CheckBox chb = (CheckBox)sender;
            GridViewRow container = (GridViewRow)chb.NamingContainer;
            object dataValue = ((DataRowView)container.DataItem)[_columnName];
            chb.Checked = dataValue != DBNull.Value && (bool)dataValue;
        }
    }
