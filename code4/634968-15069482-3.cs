    public ActionResult ShowPreviousComments()
    {
        Comments com = new Comments();
        LstComments savedComments = new LstComments();
        ///Entity code here
        foreach (var item in comments)
        {
            com.comments = item.Comments;
            com.dTime = item.Time;
            savedComments.lstCommet.Add(com);
        }
        return PartialView(savedComments);
    }
