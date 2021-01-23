    [HttpGet]
    public JsonResult searchForSwimmers(string q)
    {
        //designed to return [{name='foo',id='bar'}]
        String[] QueryTerms = q.Split(' '); //all the search terms are sep. by " "
        var groupResults = _db.SwimGroups.Search(g => g.Name, queryTerms) 
                                         .OrderByDescending(g => g.Name.StartsWithAny(QueryTerms) ? 1 : 0)
                                         .ThenBy( g => g)
                                         .Select(g => new { name = g.Name, id = g.ID });
        return Json(groupResults,JsonRequestBehavior.AllowGet);
    }    
