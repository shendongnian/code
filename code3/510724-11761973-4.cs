            public override void DataBind()
            {
                 ...
                 GridViewDataTextColumn myCol = new GridViewDataTextColumn();
                 myCol.Caption = "col1";
                 myCol.FieldName = "dataTableField1";
                 myCol.DataItemTemplate = new ColumnDataItemTemplate();
                 theGridView.Columns.Clear();
                 theGridView.Columns.Add(myCol);
                 theGridView.DataSource = AdjustDataSource();
                 theGridView.DataBind();
                 ...
            }
        
            public class ColumnDataItemTemplate : ITemplate
            {
                public void InstantiateIn(Control container)
                {
                    GridViewDataItemTemplateContainer Container = (container as GridViewDataItemTemplateContainer);
                    LiteralControl lit = new LiteralControl("<div id='hr' style='height:100%; font-size:x-large;'>" + DataBinder.Eval(Container.DataItem, Container.Column.FieldName) + "</div>");
                    Container.Controls.Add(lit);
                }
            }
    
