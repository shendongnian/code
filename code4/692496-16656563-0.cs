    StringBuilder output = new StringBuilder();
    TagBuilder ulTag = new TagBuilder("ul");
    foreach (var item in model)
    {
        if (testCondition(item))
        {
            output.Append(ulTag.ToString());
            ulTag = new TagBuilder("ul");
        }
        ...
    }
    output.Append(ulTag.ToString();
    return output.ToString();
