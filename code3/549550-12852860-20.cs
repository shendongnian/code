    string[] AttributeTags =
        txtAttributeTags.Text.Split
        (
            new string[] { "," },
            StringSplitOptions.RemoveEmptyEntries
        );
    var newTags = AttributeTags.Except(attribute.AttributeTag.Select(item => item.something));
