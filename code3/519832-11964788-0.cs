    foreach (var modifier in AccessModifiers)
    {
        if (ArticleTextBox.Text.Contains(modifier))
        {
            UsedItems.Add(modifier);
            string openTag = "<span class='accessModifiers'>";
            string closeTag = "</span>";
            string newModifier = openTag + matchedItem + closeTag;
            newText = newText.Replace(matchedItem, newModifier);
        }
    }
