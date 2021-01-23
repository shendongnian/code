    //Repeater methode to put the values in the correct labels of the modal window 
    public void RepeaterModal_ItemDataBound(Object Sender, RepeaterItemEventArgs e) { 
        //Execute the following logic for Items and Alternating Items. 
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) { 
            ((Literal)e.Item.FindControl("ltlModalNumber")).Text = ((Groups)e.Item.DataItem).Group_Id.ToString(); 
            ((Literal)e.Item.FindControl("ltlModalGroup")).Text = ((Groups)e.Item.DataItem).Code.ToString();     
     
            //Fill the repeater inside the repeater with the students name 
            Repeater repeaterModalStudentList = ((Repeater)e.Item.FindControl("repeaterModalStudentList")); 
            repeaterModalStudentList.DataSource = ((Groups)e.Item.DataItem).Students; 
            repeaterModalStudentList.DataBind(); 
            repeaterModalStudentList.ItemDataBound += repeaterModalStudentList_ItemDataBound; 
        } 
    } 
    
    //Repeater methode to put the values in the correct labels of the modal window 
    public void repeaterModalStudentList_ItemDataBound(Object Sender, RepeaterItemEventArgs e) { 
        //Execute the following logic for Items and Alternating Items. 
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {       
     
            ImageButton imgDeleteStudent = repeaterModalStudentList.Items[0].FindControl("imgDeleteStudent") as ImageButton; 
     
            if (imgDeleteStudent != null) { 
                imgDeleteStudent.CommandArgument = ((Student)e.Item.DataItem).Student_Id.ToString(); 
            } 
        } 
    } 
     
     
    protected void btnDeleteStudent_Click(object sender, EventArgs e) {  
        ImageButton btn = (ImageButton)sender; 
        int studentId = (int)btn.CommandArgument; 
     
        Students student = new Students(); 
        student.DeleteStudent(studentId); 
     
        Response.Redirect(Request.RawUrl); 
    } 
