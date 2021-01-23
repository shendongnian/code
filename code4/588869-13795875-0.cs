    <Columns>
        <asp:TemplateField HeaderText="Customer Name">
            <ItemTemplate>
                <%# DataBinder.Eval(Container.DataItem, "Customer.Name")%>
            </ItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="PickUpPoint">
             <ItemTemplate>
                 <%# DataBinder.Eval(Container.DataItem, "Pickuppoint")%>
             </ItemTemplate>
         </asp:TemplateField>
    </Columns>
