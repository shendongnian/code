    var notInA = listB.Except(listA, myEqualityComparer);
    var notInB = listA.Except(listB, myEqualityComparer)
                       .Select(o => {
                          return new MyObject {
                             Key = item.Key,
                             Day = item.Day,
                             Value = item.Value * -1
                          };
                       });
    var listA2 = listA.Intersect(listB, myEqualityComparer)
                      .OrderBy(o => o.Key)
                      .ThenBy(o => o.Day);
    var listB2 = listB.Intersect(listA, myEqualityComparer)
                      .OrderBy(o => o.Key)
                      .ThenBy(o => o.Day);
    var diff = listA2.Zip(listB2, (first,second) => {
       return new MyObject {
         Key = first.Key,
         Day = first.Day,
         Value = second.Value - first.Value
    });
    diff = diff.Concat(notInA).Concat(notInB);
