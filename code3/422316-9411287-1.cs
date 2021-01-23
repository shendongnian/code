    return this.Context.Modules.Include("Pages")
                   .Select(p => new
                   {
                       Module = p,
                       Page = p.Pages.OrderBy(c => c.AuthOrder)
    
                   }).ToList()
                   .Select(a => a.Module)
                   .ToList();
