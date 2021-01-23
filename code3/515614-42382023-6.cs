    public async Task<IActionResult> Sites()
    {
        var items = await db.Sites.GetManyAsync();
        return Json(items.Select(s => new
        {
            s.ID,
            s.DisplayName,
            s.Url,
            UrlAlias = s.Url,
            NestedItems = s.NestedItems.Select(ni => new
            {
                ni.Name,
                ni.OrdeIndex,
                ni.Enabled,
            }),
        }));
    }
