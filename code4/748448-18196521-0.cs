    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AdventureWorksConnectionString %>" 
            SelectCommand="SELECT ProductId, StoreTime, cast(StoreTime as DateTime) as StoreTimeAsDateTime FROM junk.dbo.[Product]">
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns="False" 
            DataKeyNames="ProductID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ProductID" 
                    HeaderText="ProductID" 
                    InsertVisible="False" ReadOnly="True" 
                    SortExpression="ProductID" 
                    DataFormatString="{0:D6}" />
                <asp:BoundField DataField="StoreTime" 
                    HeaderText="StoreTime" 
                    SortExpression="StoreTime" 
                    DataFormatString="{0:hh\:mm\:ss}" />
                <asp:BoundField DataField="StoreTimeAsDateTime" 
                    HeaderText="StoreTimeAsDateTime" 
                    SortExpression="StoreTime" 
                    DataFormatString="{0:hh:mm:ss tt}" />
            </Columns>
        </asp:GridView>
    </div>
