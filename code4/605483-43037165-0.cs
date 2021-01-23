    <Grid>
        <ListView x:Name="lv" />
    </Grid>
    lv.Items.Clear();
    var gv = new GridView();
    lv.View = gv;
    var columns = new List<string> { "col1", "col2" };
    for(int index = 0; index < columns.Count; index++)
    {
        gv.Columns.Add(new GridViewColumn
        {
            Header = columns[index],
            DisplayMemberBinding = new Binding("[" + index.ToString() + "]")
        });
    }
    // Populate list
    var row1 = new List<string> { "(1, 1)", "(2, 1)" };
    var row2 = new List<string> { "(1, 2)", "(2, 2)" };
    lv.Items.Add(row1);
    lv.Items.Add(row2);
