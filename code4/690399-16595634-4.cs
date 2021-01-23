    public int Ticket
    {
        get { return Convert.ToInt32(ViewState["Ticket"] ?? 0); }
        set { ViewState["Ticket"] = value; }
    }
    // Usage
    protected void btnIssueTicket_Click(object sender, EventArgs e)
    {
         Ticket++;
         tbPrint.Text = Ticket.ToString();
    }
