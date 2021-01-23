    return context.Pages
                  .Join(context.PageTypes,
                        p => new { Id = p.PageTypeId, LangId = p.PageTypeLangId },
                        pT => new { pT.Id, pT.LangId },
                        (p, pT) => new { p, pT });
