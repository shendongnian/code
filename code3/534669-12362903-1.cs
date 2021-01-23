    <asp:DropDownList ID="DropDownList4" runat="server" 
       DataSourceID="SqlDataSource2" DataTextField="Plate" DataValueField="Plate" 
       Height="45px" Width="141px" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" >
    </asp:DropDownList>
    protected void DropDownList4_SelectedIndexChanged"(object sender, EventArgs e)
    {
        var connectionString = "your connection string from some configuration";
        var updateCmd = "UPDATE [CarTab] SET Rented = 1 WHERE ([Model] = @Model)";
        using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            SqlCommand command = new SqlCommand(updateCmd , connection);
            command.AddWithValue("@Model", DropDownList4.SelectedValue);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
    }
