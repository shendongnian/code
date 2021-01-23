            string requestedPage = Request.Url.Segments[Request.Url.Segments.Length-1];
            if (requestedPage != "UnAuthorized.aspx")
            {
            AdminUserAuthInfo au = (AdminUserAuthInfo)Context.Items["AdminUserAuthInfo"];
            int current_role= int.Parse(au.Roles[0].ToString());
            if (!AdminRole.IsPageAssignedToRole(current_role, requestedPage))
            { Response.Redirect("UnAuthorized.aspx",true); }
            }
