    string spacing = "  ";
    string newLineSpacing = string.Format("{0}{1}", Environment.NewLine, spacing);
    StringBuilder sb = new StringBuilder("mydata");
    foreach (Foo child in children)
    {
        sb.Append(Environment.NewLine);
        sb.Append(spacing);
        sb.Append(child.ToString().Replace(Environment.NewLine, newLineSpacing));
    }
