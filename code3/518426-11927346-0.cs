    [HttpGet]
    public string IngredientSearch(string search)
    {
        var sw = Stopwatch.StartNew();
        var db = new Glubee.Model.GlubeeEntities();
        var results = db.Ingredients.Where(x => x.Name.Contains(search)).ToArray();
        sw.Stop();
        return JsonConvert.SerializeObject(results);
    }
