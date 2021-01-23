    <asp:GridView ID="JobListGrid" runat="server" AutoGenerateColumns="false" >
        <Columns>
     <asp:TemplateField HeaderText="myDataTableColumn1">
            <ItemTemplate>        
               <asp:Label ID="lblTest" runat="server"
                 Text='<%# Bind("yourDataTableColumnName") %>'></asp:Label>
           <ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Actions">
       <Columns>
               <asp:ImageButton ID="View" CssClass="imgbutton" ToolTip="View Pdf" runat="server"
                    CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' ImageUrl="~/Content/pdf.PNG"  CommandName="View" Width="36" Height="36" OnClientClick='<%# Eval("JobID", "OpenInNewWindow(\"{0}\").ToString()") %>' />
                </div>
             </ItemTemplate>
           </asp:TemplateField>
        </Columns>
        </asp:GridView>
