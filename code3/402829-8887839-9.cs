    if (rootObject != null)
    {
        var firstProperty = rootObject.FirstProperty;
        if (firstProperty != null)
        {
            var secondProperty = firstProperty.SecondProperty;
            if (secondProperty != null)
            {
                var interestingString = secondProperty.InterestingString;
                if (!string.IsNullOrEmpty(interestingString))
                {
                    result = interestingString;
                }
            }
        }
    }
