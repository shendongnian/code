    public partial class Test : System.Web.UI.Page
    {
        [Serializable]
        class Recipient
        {
            public string name { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnEnter_Click(object sender, EventArgs e)
        {
            Recipient recipients = new Recipient();
            List<string> recipient = (List<string>)ViewState["recipientList"];
            
            if (recipient == null)
            {
                recipient = new List<string>();
            }
            recipients.name = txtFName.Text.Trim();
            recipient.Add(recipients.name);
            ViewState["recipientList"] = recipient;
            if (recipient.Count == 1)
            {
                lblFName.Text = recipient[0];
            }
            if (recipient.Count == 2)
            {
                lblFName1.Text = recipient[1];
            }
        }
