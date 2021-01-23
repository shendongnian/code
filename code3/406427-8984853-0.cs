    private void UpdateResultsLine(string line, List<char> foundChars)
    {
        if (txtResults.InvokeRequired)
        {
            txtResults.Invoke(
                new UpdateResultsLineDelegate(UpdateResultsLine),
                line,
                foundChars);
        }
        else
        {
            txtResults.AppendLine(
                line,
                foundChars,
                _fileType.ProcessColumns);
        }
    }
