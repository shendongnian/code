    int[] quesID;
    int i = 0;
    foreach (GridViewRow row in grdForum.Rows)
    {
     quesID[i] = Convert.ToInt16(grdForum.DataKeys[row.RowIndex].Values["TechID"].ToString());
     i++;
    }
    
    //Check this part to find out how u will implement the Contains in Linq
    var lastpost = db.tblQuestions.Where(u => quesID.Contains(quesID)).OrderByDescending(u => u.DatePosted).Take(1).ToList();
    grdnewUser.DataSource = lastpost.ToList();
    grdnewUser.DataBind();
    }
