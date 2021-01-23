    ...
    from answer in PollItemAnswers(item)
    ...
    // outside the method containing the above
    IEnumerable<object> PollItemAnswers(PollListItem item)
    {
        var y = ...;
        var v = ...;
        yield return y.Value; // return the first answer
        foreach (var checkBox in v.Items)
            if (checkBox.Selected)
                yield return checkBox.Value; // return the other answers
    }
