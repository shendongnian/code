    public override void OnResultExecuting(ResultExecutingContext filterContext)
    {
        foreach (var s in filterContext.Controller.ViewData.ModelState.Values)
        {
            for (var i = s.Errors.Count - 1; i >= 0; i--)
            {
                var e = s.Errors[i];
                if (e.Exception != null && !string.IsNullOrWhiteSpace(e.ErrorMessage))
                    s.Errors.Add(new ModelError(Translate(e.Exception), Translate(e.ErrorMessage)));
                else if (e.Exception != null)
                    s.Errors.Add(new ModelError(Translate(e.Exception)));
                else 
                    s.Errors.Add(new ModelError(Translate(e.ErrorMessage)));
                    
                s.Errors.RemoveAt(i);
            }
        }
    }
