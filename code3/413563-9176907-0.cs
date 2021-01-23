    public IList GetListNameUsers() 
    {
        using (var context = new UCDataContext()) 
        {
            return (from c in context.Users
                    select new { 
                         Name = c.LastName + " " + c.FirstName,
                         IDUser = c.IDUser
                       }
                   ).ToList();
        }
    }
    
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="UsersODS"
         DataTextField="Name" DataValueField="IDUser" />
