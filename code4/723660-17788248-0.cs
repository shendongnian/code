    protected void ChangePriority_Click(object sender, EventArgs e)
    {
        string DepartmentID = ddlDepartment.SelectedValue;
        string Description = tbImageName.Text.Trim();
        
        string Priority = ddlPriority.SelectedValue;
        //Get Filename from fileupload control
        string imgName = fileuploadimages.FileName.ToString();
        //sets the image path if exist then store image in that place else create one
        string imgPath = "Images/Departments/" + "" + ddlDepartment.SelectedValue + "/";
        bool IsExists = System.IO.Directory.Exists(Server.MapPath(imgPath));
        if (!IsExists)
            System.IO.Directory.CreateDirectory(Server.MapPath(imgPath));
        //then save it to the Folder
        fileuploadimages.SaveAs(Server.MapPath(imgPath + imgName));
        //Open the database connection
        con.Open();
        //Query to insert * into images into database
        SqlCommand cmd = new SqlCommand("Update Images set Priority=Priority+1 where Priority>='" + ddlPriority.SelectedValue + "'" + "Insert into Images(ImageName,Description,Path,Priority,DepartmentID) values(@ImageName,@Description,@Path,@Priority,@DepartmentID)", con);
        //Passing parameters to query
        cmd.Parameters.AddWithValue("@ImageName", imgName);
        cmd.Parameters.AddWithValue("@Description", Description);
        cmd.Parameters.AddWithValue("@Path", imgPath + imgName);
        cmd.Parameters.AddWithValue("@Priority", Priority);
        cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
        cmd.ExecuteNonQuery();
        //Close dbconnection
        con.Close();
        tbImageName.Text = string.Empty;
        Response.Redirect(Request.RawUrl);
    }
