    list.GroupBy(i => i.GroupId)
        .Select(g => g.Aggregate((i1, i2) => new Foo{ GroupId = i1.GroupId,
                                                      ValueA = i1.ValueA + i2.ValueA,
                                                      ValueB = i1.ValueB + i2.ValueB,
                                                    }));
