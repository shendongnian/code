    private static void FilterDropDownChoices(List<String> permittedChoices)
    {
        ddlChoices.Items.Cast<ListItem>()
           .Where(li => permittedChoices.Contains(li.Text))
           .ToList()
           .ForEach(ddlChoices.Items.Remove);
    }
