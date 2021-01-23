    <asp:GridView ID="GridView1" **OnSorting="gridViewSorting"** runat="server" />
    protected void gridViewSorting(object sender, GridViewSortEventArgs e)
    {
       DataTable dataTable = gridView.DataSource as DataTable;
       if (dataTable != null)
       {
          DataView dataView = new DataView(dataTable);
          dataView.Sort = your sort expression
          gridView.DataSource = dataView;
          gridView.DataBind();
       }
    }
