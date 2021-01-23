    using System.Linq;
    protected void newWindow(object sender, EventArgs e)
    {
        var pagesVisited = (List<int>)Session["Visited"] ?? new List<int>() { 1, 2, 3, 4, 5 };
    
        if (!pagesVisited.Any())
            // the user has visited all quizes
    
        var index = new Random().Next(0, pagesVisited.Count)
        var next =  index + 1;
    
        pagesVisited.RemoveAt(index);
    
        Session["Visited"] = pagesVisited;
        Response.Redirect(string.Format( "Question{0}.aspx", next ));
    }
