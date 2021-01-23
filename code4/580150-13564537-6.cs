    <asp:GridView runat="server" AutoGenerateColumns="False" OnRowDataBound="TestGridView_RowDataBound" ID="TestGridView">
        <Columns>
            <asp:BoundField DataField="Type" HeaderText="Assignment/Exam" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
        </Columns>
    </asp:GridView>
<!
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable tests = new DataTable();
        tests.Columns.Add(new DataColumn("Type"));
        tests.Columns.Add(new DataColumn("Name"));
        tests.AcceptChanges();
        tests.Rows.Add(new []{"Assignment","StackOverflow Basics"});
        tests.Rows.Add(new[]{"Exam","Expert Markdown"});
        tests.Rows.Add(new[]{"Exam","Upvoting"});
        tests.Rows.Add(new[]{"Assignment","Rep Changes"});
        TestGridView.DataSource = tests;
        TestGridView.DataBind();
    }
