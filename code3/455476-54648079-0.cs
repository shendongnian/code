      <script runat="server">
        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
        e.Command.CommandTimeout = 0;
        }
        </script>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="Your Connection String" 
    ProviderName="Teradata.Client.Provider"
    SelectCommand="A SELECT COMMAND THAT TAKES A LONG TIME"
    DataSourceMode="DataSet"
    onselecting="SqlDataSource1_Selecting">
