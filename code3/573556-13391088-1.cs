    protected void ...some method on your view or asp page {
        YourDbAccessClass db = new YourDbAccessClass();
        var comments = db.GetCommentsByStudentId(yourIdVariableHere);
        // Now you can loop through those items without dbcontext.
        // Response.Write is probably a bad example, but you probably get the gist here.
        foreach(var comment in comments) {
            Response.Write("<li>" + comment.Student.Name + "</li>");
        }
    }
