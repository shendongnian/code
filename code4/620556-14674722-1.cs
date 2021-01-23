    [HttpPost]
    public ActionResult GetEntries(string firstLetter)
    {
        Debug.WriteLine(firstLetter);
        return new EmptyResult();
    }
