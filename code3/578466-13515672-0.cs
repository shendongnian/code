    protected void Page_Load(object sender, EventArgs e)
    {
        count = 0;             
        switch (Request.QueryString["status"])
        {
            case "active":
                lblUserListTitle.Text = "Activated user accounts";
                break;
            case "inactive":
                lblUserListTitle.Text = "Inactive user accounts";
                break;
            case "locked":
                lblUserListTitle.Text = "Locked user accounts";
                break;
            case "online":
                lblUserListTitle.Text = "Users online";
                break;
            case "notverified":
                lblUserListTitle.Text = "Users accounts not yet verified";
                break;
            default:
                lblUserListTitle.Text = "All user accounts";
                break;
        }
        if (!IsPostBack)
        {
            MembershipUserCollection usersList = Membership.GetAllUsers();
            MembershipUserCollection filteredUsers = new MembershipUserCollection();
            foreach (MembershipUser user in usersList)
            {
                if (!Roles.IsUserInRole(user.UserName, "Admin") && !Roles.IsUserInRole(user.UserName, "Engineering"))
                {
                    userProfile = Profile.GetProfile(user.UserName);
                    if (txtFilterCustomerNo.Text.Length > 0)
                    {
                        ProfileCommon PC = Profile.GetProfile(user.UserName);
                        if (PC.RaymarineAccountNo == txtFilterCustomerNo.Text.ToUpper())
                        {
                            filteredUsers.Add(user);
                            count++;
                        }
                    }
                    else
                    {
                        //filter on querystring
                        if (Request.QueryString["status"] == "active")
                        {
                            if (user.IsApproved && !user.IsLockedOut)
                            {
                                filteredUsers.Add(user);
                                count++;
                            }
                        }
                        else if (Request.QueryString["status"] == "inactive")
                        {
                            if (!user.IsApproved && !user.IsLockedOut)
                            {
                                filteredUsers.Add(user);
                                count++;
                            }
                        }
                        else if (Request.QueryString["status"] == "locked")
                        {
                            if (user.IsLockedOut)
                            {
                                filteredUsers.Add(user);
                                count++;
                            }
                        }
                        else if (Request.QueryString["status"] == "online")
                        {
                            if (user.IsOnline)
                            {
                                filteredUsers.Add(user);
                                count++;
                            }
                        }
                        else if (Request.QueryString["status"] == "notverified")
                        {
                            if (user.IsApproved && !userProfile.IsVerified)
                            {
                                filteredUsers.Add(user);
                                count++;
                            }
                        }
                        else
                        {
                            filteredUsers.Add(user);
                            count++;
                        }
                    }
                }
            }
            if (Session["FilteredUsers"] == null)
                Session.Add("FilteredUsers", new MembershipUserCollection());
            Session["FilteredUsers"] = filteredUsers;
        }
        BindGrid();    
        lblSearchResult.Text = "There are " + count.ToString() + " registered users found.";
    }
    protected void BindGrid()
    {    
        GridView1.DataSource = (MembershipUserCollection)Session["FilteredUsers"];
        GridView1.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGrid();
    }
