     public override void DataBind()
                {
                    ...
                    GridViewDataTextColumn myCol = new GridViewDataTextColumn();
                    myCol.Caption = "col1";
                    myCol.FieldName = "dataTableField1";
                    theGridView.Columns.Clear();
                    theGridView.Columns.Add(myCol);
                    theGridView.DataSource = AdjustDataSource();
                    theGridView.DataBind();
                    theGridView.CustomColumnDisplayText += new ASPxGridViewColumnDisplayTextEventHandler(theGridView_CustomColumnDisplayText);
                    ...
                }
    
            public class ColumnDataItemTemplate : ITemplate
            {
                public void InstantiateIn(Control container)
                {
                    GridViewDataItemTemplateContainer Container = (container as GridViewDataItemTemplateContainer);
                    LiteralControl lit = new LiteralControl("<div id='hr' style='height:100%; font-size:large;'><%# Eval(\"" + Container.Column.FieldName + "\") %></div>");
                    Container.Controls.Add(lit);
                }
            }
    
            private void theGridView_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
            {
                if (e.Column.FieldName == "dataTableField1")
                    try
                    {
                        e.Column.DataItemTemplate = new ColumnDataItemTemplate();
                    }
                    catch { }
            }
