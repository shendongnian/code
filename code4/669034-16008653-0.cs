    List<Literal> persistControls = new List<Literal>();
    protected void Page_Load(object sender, EventArgs e)
    {          
         display();           
    }
    
    protected void commentButton_Click(object sender, EventArgs e)
    {
        Literal myComment = new Literal();
        myComment.Text = "<p>" + commentBox.Text + "</p><br />";
        commentPanel.Controls.Add(myComment);
        persistControls.Insert(0,myComment);
        Session["persistControls"] = persistControls; 
        display();
    }
    void display()
    {
        // if you already have some literal populated
        if (Session["persistControls"] != null)
        {
            // pull them out of the session
            persistControls = (List<Literal>)Session["persistControls"];
            foreach (Literal ltrls in persistControls)
                commentPanel.Controls.Add(ltrls); // and push them back into the page
        }
    }
