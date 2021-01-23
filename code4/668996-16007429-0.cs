         Literal comment = new Literal();
        comment.Text="";
   
        Panel1.Controls.Add(comment);
        if (Panel1.Controls.Contains(comment))
        {
            comment.Text = comment.Text + "<p>" + commentbox.Text + "</p>";
        }
