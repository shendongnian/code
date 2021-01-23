    <DataGrid behaviors:DataGridColumnCollection.ColumnsSource="{Binding ColumnHeaders}"
              behaviors:DataGridColumnCollection.DisplayMemberFormatMember="Format"                         behaviors:DataGridColumnCollection.DisplayMemberMember="DisplayMember"
                          behaviors:DataGridColumnCollection.FontWeightBindingMember="FontWeightMember"
                          behaviors:DataGridColumnCollection.HeaderTextMember="Header"
                          behaviors:DataGridColumnCollection.SortMember="SortMember"
                          behaviors:DataGridColumnCollection.TextAlignmentMember="TextAlignment"
                          behaviors:DataGridColumnCollection.TextColourMember="TextColourMember"
                          behaviors:DataGridColumnCollection.WidthMember="Width"
                          ItemsSource="{Binding Items}">
