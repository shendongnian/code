    Predicate ToOrTree(List<Foo> fooList) {
        if (fooList.Count > 2) {
            var firstHalf = fooList.Count / 2;
            var lhs = ToOrTree(fooList.Take(firstHalf).ToList());
            var rhs = ToOrTree(fooList.Skip(firstHalf).ToList());
            return lhs.Or(rhs);
        }
        Predicate res = PredicateBuilder.Create<Foo>(
            foo => fooList[0].Bar == foo.Bar &&  fooList[0].Baz == foo.Baz
        );
        if (fooList.Count == 2) {
            res = res.Or(
                foo => fooList[1].Bar == foo.Bar &&  fooList[1].Baz == foo.Baz
            );
        }
        return res;
    }
