    TextPattern textPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
    object roAttribute = textPattern.DocumentRange.GetAttributeValue(TextPattern.IsReadOnlyAttribute);
    if (roAttribute != TextPattern.MixedAttributeValue)
    {
        bool isReadOnly = (bool)roAttribute;
    }
    else
    {
        // Different subranges have different read only statuses
    }
