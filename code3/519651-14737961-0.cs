    This is what I did that worked for me:
    
    **Snippet from aspx:**
    
      <asp:TemplateField HeaderText="RECORD_STATUS" SortExpression="RECORD_STATUS">
         <EditItemTemplate>
            <asp:DropDownList  runat="server" ID="ddlRecStatus"                                                SelectedIndex='<%# GetselectedRecStatus(Eval("RECORD_STATUS")) %>'
                                        DataSource = '<%# Recs_Status %>' />
                                </EditItemTemplate>
      </asp:TemplateField>
    
    **Snippet from code-behind:**
    
     protected void grdSAEdit_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
                //Get the refernce to the list control
                DropDownList ddlRecStatus = (DropDownList)(grdSAEdit.Rows[e.RowIndex].FindControl("ddlRecStatus"));
    
                // Add it to the parameters
                e.NewValues.Add("RECORD_STATUS", ddlRecStatus.Text);
    
            }
    
            protected string[] Recs_Status
            {
                get { return new string[] {  "A", "E", "V", "Z" }; }
            }
    
            protected int GetselectedRecStatus(object status)
            {
                return Array.IndexOf(Recs_Status, status.ToString());
            }
