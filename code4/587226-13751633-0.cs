    List<TypeA> groupedList = TypeAList
      .GroupBy(a => a.identifierA)
      .Select(g => new TypeA()
      {
        identierA = g.Key,
        number = g.Sum(a => a.number)
        nestedList = g.SelectMany(a => a.nestedList)
          .GroupBy(b => b.identifierB)
          .Select(g2 => new TypeB()
          {
            identifierB = g2.Key,
            otherNumber = g2.Sum(b => b.otherNumber)
          }
      }
