    return context.Pages
                  .Where(x => x.PageTypeLangId.HasValue)
                  .Join(context.PageTypes,
                        p => new { Id = p.PageTypeId,
                                   LangId = p.PageTypeLangId.Value },
                        pT => new { pT.Id, pT.LangId },
                        (p, pT) => new { p, pT });
