    private void OperatorQualificationsTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if ((OperatorQualificationsTable.SelectedItem != null) && (e.OriginalSource?.Equals(OperatorQualificationsTable) ?? false))
        {
            OperatorQualificationsTable.ScrollIntoView(OperatorQualificationsTable.SelectedItem);
        }
    }
