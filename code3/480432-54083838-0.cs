    var twoOfThree = ACherryIsA.Fruit | ACherryIsA.Tree;
    Console.WriteLine(
        "Name: " + String.Join(
            ",", 
            ((ACherryIsA[])Enum.GetValues(typeof(ACherryIsA)))
            .Where(e => twoOfThree.HasFlag(e))
        )
    );   // => Name: Tree,Fruit
