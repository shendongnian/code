    public async Task<IActionResult> Sites()
    {
        var items = await db.Sites.GetManyAsync();
        return Json(items.ToList(), new JsonSerializerSettings
        {
            ContractResolver = new MyJsonContractResolver()
            {
                ExcludeProperties = new List<Tuple<string, string>>
                {
                    Tuple.Create("Site", "Name"),
                    Tuple.Create("<TypeName>", "<MemberName>"),
                }
            }
        });
    }
