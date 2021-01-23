    Put the controls in a div where all the details to be exported.Export the div to excel.
    
    let the aspx file be like this   
    
      <div id="divExport" runat="server">
        <div id="dvheads" runat="server">
            <b>
              <label id="lblCustomerName" runat="server"></label><br /><br />
              <label id="lblAddress" runat="server"></label><br /><br />
              <label id="lblPin" runat="server"></label>
                </b>
        </div>
            <br />
            
            <asp:GridView ID="GVLoans" runat="server" CellPadding="4" ForeColor="#333333"  AutoGenerateColumns="False" >
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" HorizontalAlign="left" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                <Columns>
                    <asp:TemplateField>
                <HeaderTemplate>Sl No</HeaderTemplate>
                <ItemTemplate>
                <asp:Label ID="lblSRNO" runat="server" 
                    Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                </Columns>
            </asp:GridView>
        
            <br />
            </div>
    
    
    In .cs file  the code for export will be like this
    
     protected void btnSave_Click(object sender, EventArgs e)
            {
        Response.Clear();
        Response.AddHeader("content-isposition",attachment;filename=testExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        divExport.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
