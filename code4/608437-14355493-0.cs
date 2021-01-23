    public ActionResult asdf(TModel model, ModelStateDictionary state) 
    {
        var result = View(this.Partial, model);
        result.ViewData.ModelState.Clear();
        foreach (var pair in state.Where(m=> m.Value != null && m.Value.Errors.Any()))
        {
            result.ViewData.ModelState.AddModelError(pair.Key, string.Join(",",pair.Value.Errors.Select(e=>e.ErrorMessage).ToArray()));
        }  
        return result;
    }
 
