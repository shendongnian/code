    [Flags]
    public enum ACherryIsA
    {
        Tree = 1,
        Fruit = 2,
        SorryWhatWasTheQuestionAgain = 4,
        FruitTree = Tree | Fruit,
    }
    public static void Main()
    {
        var twoOfThree = ACherryIsA.Fruit | ACherryIsA.Tree;
        Console.WriteLine(
            "Name: " + String.Join(
                ",", 
                ((ACherryIsA[])Enum.GetValues(typeof(ACherryIsA)))
                .Where(e => twoOfThree.HasFlag(e))
            )
        );   // => Name: Tree,Fruit,FruitTree
    }
