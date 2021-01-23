    <asp:Label runat="server" ID="Label1"></asp:Label>
    <asp:Table runat="server" ID="table1"></asp:Table>
    <asp:Button runat="server" ID="Button1" OnClick="Button1_Click" 
       Text="Create TextBoxes" />
    <asp:Button runat="server" ID="Button2" OnClick="Button2_Click" 
      Text="Submit" />
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            // Reload those control back. It can be in either init or load event.
            int total = Count;
            Label1.Text = total.ToString();
    
            for (int i = 0; i < total; i++)
                CreateTextBoxes(i);
    
            Count = total;
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        Count = Count++;
        CreateTextBoxes(Count);
    
        if (Count == 4)
        {
            Button1.Visible = false;
        }
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        var results = new List<string>();
        foreach (TableRow row in table1.Rows)
        {
            foreach (TableCell cell in row.Cells)
            {
                var textBox = cell.Controls[0] as TextBox;
                if (textBox != null)
                {
                    results.Add(textBox.Text);
                }
            }
        }
        Label1.Text += string.Join(",", results);
    }
    
    private int Count
    {
        get { return Convert.ToInt32(ViewState["count"] ?? "0"); }
        set { ViewState["count"] = value; }
    }
    
    private void CreateTextBox(int j)
    {
        var box = new TextBox();
        box.ID = "Textbox" + j;
        box.Text = "Textbox" + j;
    
        var c = new TableCell();
        c.Controls.Add(box);
    
        var r = new TableRow();
        r.Cells.Add(c);
    
        table1.Rows.Add(r);
    }
