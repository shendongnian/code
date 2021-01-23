    Dim lFinal2 = From el In a
                  Group el By Key = New With {Key el.Description, Key el.Activity} Into Group
                  Select New With {
                      .Activity = Key.Description,
                      .Country = Key.Activity,
                      .MonthCost =
                          (From k In Group.SelectMany(Function(g) g.MonthCosts.Keys).Distinct()
                           Select New With {
                                .Month = k,
                                .Sum = Group.Sum(Function(g) If(g.MonthCosts.ContainsKey(k), g.MonthCosts(k), 0))
                           }).ToDictionary(Function(i) i.Month, Function(i) i.Sum)
                  }
