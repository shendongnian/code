    protected void Page_Load(object sender, EventArgs e)
    {
    using(var db = new myDataContext()) // see linq to sql / entity framework
       foreach(var i in db.ImagesTable.Select(img => new { Id = img.Id }))  // ImagesTable is the name of your table with info about your images
          myimages.Controls.Add(new LiteralControl(@"<img src=""myimgdir/" + i.Id + "".jpg" class=""stackphotos"" />")); // presuming that images are named according to an id in the database
    }
