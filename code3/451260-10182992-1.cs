    string baseUrl = "http://localhost/myapp";
    case NewCourseRequestView.Administrator:
        if (access.Administrator)
        {
            UserTypeLabel.Text = "Administrator Details:";
            AdministratorMenuList.Items.Add(new UrlText(baseUrl + "/viewunapproved.aspx", "View Un-Approved Requests"));
            adminContent.Visible = true;
        }
        break;
    
    case NewCourseRequestView.Requestor:
        if (access.Requestor)
        {
            UserTypeLabel.Text = "Requester Details:";
            RequestorMenuList.Items.Add(new UrlText(baseUrl + "/RequestCourse.aspx","Request A New Course"));
            RequestorMenuList.Items.Add(new UrlText(baseUrl + "/viewNewRequest.aspx","View My New Course Requests"));
            requestContent.Visible = true;
        }
        break;
