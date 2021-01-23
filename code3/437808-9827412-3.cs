    public IEnumerable<UserSummary> getUserSummaryList()
    {
        using (var db = new EntityContext())
        {
            foreach (aspnet_Users user in users)
            {
                // Retrieve the username (with logic if it is null or empty)
                var username = user.UserName;
                // Retrieve the email (with logic if it is null or empty)
                var email = (user.aspnet_Membership != null)
                    ? user.aspnet_Membership.Email ?? String.Empty
                    : String.Empty;
                // Retrieve the role (with logic if it is null)
                var roles = Roles.GetRolesForUser(username);
                var role = (roles != null) ? roles.FirstOrDefault() : null;
                // Retrieve the Ad Company (with logic if it is null)
                var adCompany = (user.AD_COMPANIES != null)
                    ? user.AD_COMPANIES.ad_company_name ?? "Not an Advertiser"
                    : "Not an Advertiser";
                var empName = (user.EMPLOYEE != null)
                    ? user.EMPLOYEE.emp_name ?? "Not an Employee"
                    : "Not an Employee";
                yield return new UserSummary
                    {
                        UserName     = username,
                        Email        = email,
                        Role         = role,
                        AdCompany    = adCompany,
                        EmployeeName = empName,
                    };
            }
        }
    }
