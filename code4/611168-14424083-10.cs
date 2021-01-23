    public static string GetOutline(int indentLevel, XElement element)
    {
        return ShowGroup(indentLevel, new[] {element});
    }
    
    /// <summary>
    /// Returns the outline of the elements that constitute a group.
    /// </summary>
    /// <param name="indentLevel">Indent level.</param>
    /// <param name="elements">Elements of a group (all the element of the collection must have the same <c>Name</c>)</param>
    /// <returns>Outline of the group.</returns>
    private static string ShowGroup(int indentLevel, IEnumerable<XElement> elements)
    {
        StringBuilder result = new StringBuilder();
    
        result = result.AppendLine(new string('-', indentLevel * 6) + elements.First().Name);
    
        foreach (var childGroup in from element in elements
                                   from childElement in element.Elements()
                                   group childElement by childElement.Name into childGroup
                                   select childGroup)
            result.Append(ShowGroup(indentLevel + 1, childGroup));
    
        return result.ToString();
    }
