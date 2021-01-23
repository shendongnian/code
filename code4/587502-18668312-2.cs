    var listA = new List<ClassA> {
       new ClassA(1, "OneA"),
       new ClassA(2, "TwoA"),
       new ClassA(3, "ThreeA")
    };
    var listB = new List<ClassB> {
       new ClassB(1, "OneB"),
       new ClassB(2, "TwoB"),
       new ClassB(4, "FourB")
    };
    listA
    .Join(
       listB,
       itemA => itemA.Id,
       itemB => itemB.Id,
       (itemA, itemB) => new { ItemA = itemA, ItemB = itemB }
    ).ForEach(pair => pair.ItemA.myObjectB = pair.ItemB);
    listA.ForEach(itemA => Console.WriteLine(
       "{0} maps to {1}",
       itemA == null
          ? "null"
          : itemA.name,
       (itemA == null || itemA.myObjectB == null)
          ? "null"
          : itemA.myObjectB.name
    ));
