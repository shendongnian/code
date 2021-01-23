    public partial class WebForm2 : System.Web.UI.Page
    {
        bool bFlag = true;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillddlLocations();
            }
        }
    
        //Properties to store selected value in ViewState
    
        protected string MemberID1Selection
        {
            get
            {
                if (ViewState["MemberID1Selection"] != null)
                    return ViewState["MemberID1Selection"].ToString();
                return "";
            }
            set { ViewState["MemberID1Selection"] = value; }
        }
    
        protected string MemberID2Selection
        {
            get
            {
                if (ViewState["MemberID2Selection"] != null)
                    return ViewState["MemberID2Selection"].ToString();
                return "";
            }
            set { ViewState["MemberID2Selection"] = value; }
        }
    
        protected string MemberID3Selection
        {
            get
            {
                if (ViewState["MemberID3Selection"] != null)
                    return ViewState["MemberID3Selection"].ToString();
                return "";
            }
            set { ViewState["MemberID3Selection"] = value; }
        }
    
    
        protected void FillddlLocations()
        {
            FillDropdown(memberID1);
            FillDropdown(memberID2);
            FillDropdown(memberID3);
            memberID1.Visible = true;
            memberID2.Visible = true;
            memberID3.Visible = true;
        }
    
        protected void FillDropdown(DropDownList ddl)
        {
    
            using (var connAdd = new SqlConnection("Data Source = localhost; Initial Catalog = MajorProject; Integrated Security= SSPI"))
            {
                connAdd.Open();
    
                var sql = "Select policeid from PoliceAccount where status ='available' and handle ='offcase' and postedto='" + ddllocation.SelectedValue + "'";
                using (var cmdAdd = new SqlDataAdapter(sql, connAdd))
                {
                    DataSet ds2 = new DataSet();
                    cmdAdd.Fill(ds2);
    
                
                    ddl.Items.Clear();
                    ddl.DataSource = ds2;
                    ddl.DataTextField = "memberID";
                    ddl.DataValueField = "memberID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("Please select a Member ID", ""));
                    ddl.SelectedIndex = 0;
    
                }
    
            }
        }
    
        protected void IndexChanged(DropDownList ddlChanged, DropDownList ddlToFilter1, DropDownList ddlToFilter2)
        {
            string removeValue1 = ddlChanged == memberID1 ? MemberID1Selection : (ddlChanged == memberID2 ? MemberID2Selection : MemberID3Selection);
            string selValue2 = ddlChanged == memberID1 ? MemberID2Selection : (ddlChanged == memberID2 ? MemberID1Selection : MemberID1Selection);
            string selValue3 = ddlChanged == memberID1 ? MemberID3Selection : (ddlChanged == memberID2 ? MemberID3Selection : MemberID2Selection);
                
            bFlag = false;//Prevent fireing the code again while changing the index
            if (removeValue1 != "")
            {
                ListItem item1 = ddlToFilter1.Items.FindByValue(removeValue1);
                ddlToFilter1.Items.Remove(item1);
                ListItem item2 = ddlToFilter2.Items.FindByValue(removeValue1);
                ddlToFilter2.Items.Remove(item2);            
            }
    
            if (selValue3 != "")
            {
                ListItem item3 = ddlToFilter1.Items.FindByValue(selValue3);
                ddlToFilter1.Items.Remove(item3);
            }
            if (selValue2 != "")
            {
                ListItem item4 = ddlToFilter2.Items.FindByValue(selValue2);
                ddlToFilter2.Items.Remove(item4);
            }
    
            bFlag = false;
            ddlToFilter1.SelectedIndex = ddlToFilter1.Items.IndexOf(ddlToFilter1.Items.FindByValue(selValue2));
            ddlToFilter2.SelectedIndex = ddlToFilter2.Items.IndexOf(ddlToFilter2.Items.FindByValue(selValue3));
        }
    
        protected void ddlpid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MemberID1Selection = memberID1.SelectedValue;
            if (bFlag)
            {
                FillDropdown(memberID2);
                FillDropdown(memberID3);
                IndexChanged(memberID1, memberID2, memberID3);
            }
        }
    
        protected void ddlpid2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MemberID2Selection = memberID2.SelectedValue;
            if (bFlag)
            {
                FillDropdown(memberID1);
                FillDropdown(memberID3);
                IndexChanged(memberID2, memberID1, memberID3);
            }
        }
        protected void ddlpid3_SelectedIndexChanged(object sender, EventArgs e)
        {
            MemberID3Selection = memberID3.SelectedValue;
            if (bFlag)
            {
                FillDropdown(memberID1);
                FillDropdown(memberID2);
                IndexChanged(memberID3, memberID1, memberID2);
            }
        }
    }
     
    
