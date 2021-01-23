    [HttpPost]
    public ActionResult Upload(HttpPostedFileBase file)
    {
        // ... some processing
        var redirectToUrl = Url.Action(
            "Create", 
            "Album",
            new { url = url, isLocalFile = isLocalFile }
        );
        return new TextareaJsonResult(new { redirectToUrl = redirectToUrl });
    }
