       <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="False" 
             DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
        
       protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
       {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                TableCell Cell = e.Row.Cells[i];
    
                // if both row and column are odd, color then black
                // if both row and column are even, color then yellow
                if (((e.Row.RowIndex % 2 == 1) && (i % 2 == 1)) ||
                    ((e.Row.RowIndex % 2 == 0) && (i % 2 == 0)))
                    Cell.BackColor = Color.Black;
                else
                    Cell.BackColor = Color.Yellow;
            }
        }
