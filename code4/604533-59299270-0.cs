    <asp:TemplateField>
       <ItemTemplate>
      <asp:LinkButton runat="server" ID="LnKB" Text='edit' OnClick="LnKB_Click"   > 
     </asp:LinkButton>
     </ItemTemplate>
    </asp:TemplateField>
      protected void LnKB_Click(object sender, System.EventArgs e)
      {
            LinkButton lb = sender as LinkButton;
           
            GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
            int x = clickedRow.RowIndex;
            int id = Convert.ToInt32(yourgridviewname.Rows[x].Cells[0].Text);
            lbl.Text = yourgridviewname.Rows[x].Cells[2].Text; 
       }
