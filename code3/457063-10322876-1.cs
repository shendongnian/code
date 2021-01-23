    public ActionResult Index()
    {
        Response.Clear();
        Response.Clear();
        Response.ContentType = "application/CSV";
        Response.AddHeader("content-disposition", "attachment; filename=\"filename.csv\"");
        String temp = "email,f_name,l_name,c_name,ids,abc1@test.com,CG,Wander,C1,abc2@Atest.COM,Virginia,Dale,A & D";
        Response.Write(temp);
        Response.End();
        return View();
    }
