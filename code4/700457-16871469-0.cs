    void showData()
    {
     tempExp = (string)Session["sort"];
     sortProperty = SortDirection.Descending;
     sortedView = new DataView(dataset);
     String newSort = tempExp == 'Data1' ? 'A' : 'B'; // Use the Alias to sort 
     sortedView.Sort = newSort + " Desc"; 
     GridView1.DataSource = sortedView;
     GridView1.Columns['A'].Visible = false; // Hide sorting column A to the user
     GridView1.Columns['B'].Visible = false; // Hide sorting column B to the user
     GridView1.DataBind();
    }
