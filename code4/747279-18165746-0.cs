    var result = FamilyToEnumerable(familyRoot)
                    .Where(f => f.Name == "FamilyD");
    IEnumerable<Family> FamilyToEnumerable(Family f)
    {
        Stack<Family> stack = new Stack<Family>();
        stack.Push(f);
        while (stack.Count > 0)
        {
            var family =  stack.Pop();
            yield return family;
            foreach (var child in family.Children)
                stack.Push(child);
        }
    }
