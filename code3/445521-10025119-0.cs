    public partial class Default : Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var datacontext = new DataClasses1DataContext();
                List<Company> companies = datacontext.Companies.ToList();
                DropDownList1.DataSource = companies;
                DropDownList1.DataValueField = "CompanyID";
                DropDownList1.DataTextField = "CompanyName";
                DropDownList1.DataBind();
            }
        }
        public void DropDownList1SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var dc = new DataClasses1DataContext())
            {
                DetailsView2.DataSource = null;
                DetailsView2.DataBind();
                DetailsView1.DataSource = dc.Companies.Where(d => d.CompanyID.Equals(DropDownList1.SelectedValue)).ToList();
                DetailsView1.DataBind();
                List<Contact> contacts = 
                dc.Contacts.Where(d => d.CompanyID.Equals(DropDownList1.SelectedValue)).ToList();            
                DropDownList2.DataSource = contacts;
                DropDownList2.DataTextField = "LastName";
                DropDownList2.DataValueField = "ContactID";
                DropDownList2.DataBind();
                if (contacts.Any())
                {
                    DetailsView2.DataSource = dc.Contacts.Where(c => c.ContactID.Equals(DropDownList2.SelectedValue)).ToList();
                    DetailsView2.DataBind();
                }
                
            }
        }
        public void DropDownList2SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var dc = new DataClasses1DataContext())
            {
                DetailsView2.DataSource = dc.Contacts.Where(c => c.ContactID.Equals(DropDownList2.SelectedValue)).ToList();
                DetailsView2.DataBind();
            }
        }
    }
