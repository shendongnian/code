      protected void RadGrid1_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
            if (e.Column.IsBoundToFieldName("ProductID"))
            {
                e.Column.ItemStyle.CssClass = "MyClass1";
            }
            else if (e.Column.IsBoundToFieldName("ProductName"))
            {
                e.Column.ItemStyle.CssClass = "MyClass2";
            }
        }
    
    ...
        <style type="text/css">
            .MyClass1
            {
                color: Red;
            }
            
             .MyClass2
            {
                color: Blue;
            }
        </style>
