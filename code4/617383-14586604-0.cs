    if(orderedModels.Count == 0)
                {
                    var codesByTag = db.Code.Where(c => c.Tags.Any(t => t.TagName.ToUpper().Contains(searchString))).ToList<Code>();
                    foreach (var searchResult in codesByTag)
                    {
                        orderedModels.Add(MapCodeToModel(searchResult));
                    }
                }
