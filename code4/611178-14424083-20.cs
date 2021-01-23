    public static string GetOutline(int indentLevel, XElement element)
    {
        return GetGroupOutline(indentLevel, new[] {element});
    }
    
    /// <summary>
    /// Returns the outline of the elements that constitute a group.
    /// </summary>
    /// <param name="indentLevel">Indent level.</param>
    /// <param name="elements">Elements of a group (all the element of the collection must have the same <c>Name</c>)</param>
    /// <returns>Outline of the group.</returns>
    private static string GetGroupOutline(int indentLevel, IEnumerable<XElement> elements)
    {
        StringBuilder result = new StringBuilder();
    
        // Adds the group name in the outline
        result = result.AppendLine(new string('-', indentLevel * 6) + elements.First().Name);
    
        foreach (var childGroup in from element in elements  // Gets each element in the group "elements"
                                   from childElement in element.Elements()  // Gets their children
                                   group childElement by childElement.Name into childGroup  // Groups the children of all elements by their name to a new group called "childGroup"
                                   select childGroup)
            result.Append(GetGroupOutline(indentLevel + 1, childGroup));  // Shows the outline of the group called "groupChild"
    
        return result.ToString();
    }
