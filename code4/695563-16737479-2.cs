    public class Member
    {
        public int ID { get; set; }
        public string MemberName { get; set; }
        public int Owes { get; set; }
        public int Paid { get; set; }
        public DateTime? CureExpires { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            PendingList.DataSource = new List<Member>
                {
                    new Member {ID = 1, MemberName = "John", Owes = 10, 
                        Paid = 5, CureExpires = new DateTime(2013, 5, 25)},
                    new Member {ID = 2, MemberName = "Sam", Owes = 100, 
                        Paid = 50, CureExpires = new DateTime(2013, 5, 23)},
                    new Member {ID = 3, MemberName = "Mark", Owes = 12, 
                        Paid = 2, CureExpires = new DateTime(2013, 6, 1)},
                    new Member {ID = 3, MemberName = "Lisa", Owes = 40, 
                        Paid = 35, CureExpires = null},
                };
            PendingList.DataBind();
        }
    }
    
    protected void PendingList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var expiresLiteral = e.Row.FindControl("ExpiresLiteral") as Literal;
            var member = e.Row.DataItem as Member;
    
            if (!member.CureExpires.HasValue)
                expiresLiteral.Text = "N/A";
            else if (member.CureExpires.Value < DateTime.Now)
                expiresLiteral.Text = "Expired";
            else
                expiresLiteral.Text = member.CureExpires.Value.ToShortDateString();
        }
    }
        
    <asp:GridView runat="server" ID="PendingList" AutoGenerateColumns="False" 
      OnRowDataBound="PendingList_RowDataBound">
        <Columns>
            <asp:BoundField DataField="MemberName" HeaderText="Member Name" />
            <asp:BoundField DataField="Owes" HeaderText="Owes" />
            <asp:BoundField DataField="Paid" HeaderText="Paid" />
            <asp:TemplateField HeaderText="Expires">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ExpiresLiteral" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="ID"   
                 DataNavigateUrlFormatString="Payment.aspx?ID={0}"
                Text="Record Payment" HeaderText="" />
        </Columns>
    </asp:GridView>
