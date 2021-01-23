    result.Items = query.OrderBy(x => x.UserName).Skip(page * pageSize)
                                .Take(pageSize)
                                .Select(x => new jQGridModel.jQGridModelItem
                                {
                                    UserItem = x,
                                    ItemsSold = (from o in db.Order
                                                 where
                                                     o.PromoCode.Equals(x.PromoCode)
                                                 select o).Count()
                                })
                                .ToList();
