    var menuItems = _menuRepository.GetPk(pk)
        .Where(m => m.Status == "00")
        .OrderBy(m => m.Order)
        .Select(m =>
                    {
                        var orderOrEmpty = m.Order ?? "00000000";
                        return new MenuItem
                                    {
                                        PartitionKey = m.PartitionKey,
                                        RowKey = m.RowKey,
                                        Order = m.Order,
                                        Order1 = orderOrEmpty.Substring(0, 1),
                                        Order2 = orderOrEmpty.Substring(2, 1),
                                        Order3 = orderOrEmpty.Substring(4, 1),
                                        Order4 = orderOrEmpty.Substring(6, 2),
                                        Title = m.Title,
                                        Type = m.Type,
                                        Link = m.Link,
                                        TextLength = m.TextLength
                                    };
                    });
