    SPListItemCollection itemCol = null;
        SPSite site = new SPSite(http://yoursharepointsite);
        SPWeb web = site.OpenWeb();
        SPList list = web.Lists["Courses"]; //Name of your List with Courses
        SPQuery qryCourse = new SPQuery();
        qryCourse.Query = "<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>" + dropList.SelectedItem.Text + "</Value></Eq></Where>";
        qryCourse.ViewFields = "<FieldRef Name='Instructor'/>"; //You want the Instructor Column to display
        try
        {
            itemCol = list.GetItems(qryCourse);
            foreach (SPListItem item in itemCol)
            {
                lblInstructorName.Text = item["Instructor"].ToString();
            }
        }
        catch (NullReferenceException)
        {
            lblInstructorName.Text = "Some Kind of Error!";
        }
