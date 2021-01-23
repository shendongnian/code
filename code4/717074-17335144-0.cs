    var doc = XDocument.Load(Server.MapPath("~/Data/comments.xml"));
    var result = doc.Descendants("comments")
                    .Where(x => x.Element("postid").Value == 
                                Request.QueryString["id"] && 
                                x.Element("status").Value == "Y")
                    .Select(x => new
    {
        id= (string)x.Element("id"),
        name = (string)x.Element("name"),
        comment = (string)x.Element("Comment"),
        commenttime = x.Element("CommentTime")
        //status=x.Element("status").Value
    }).OrderByDescending(x => x.id).Take(1);
    Repeater2.DataSource = result;
    Repeater2.DataBind();
