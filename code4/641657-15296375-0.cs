     var values = context.Table1.Select()
                            .GroupJoin(
                                        context.Table2.Select(),
                                        detail => detail.ID,
                                        entry => entry.ID,
                                        (detail, entry) =>
                                            new { //select columns })
                                         .DefaultIfEmpty()
                                         .GroupJoin(
                                                context.Table3.Select(),
                                                entry => entry.Id,
                                                check => check.NonKeyColumn,
                                                (entry, check) => new {//select additional columns})
                                         .DefaultIfEmpty()
                                         .GroupJoin(
                                                context.Table4.Select(),
                                                entry => entry.ID,
                                                transactions => transactions.ID,
                                                (entry, transactions) => new {//select additional columns})
                                         .DefaultIfEmpty();
