	/// <summary>
	/// Select an option by first searching for a case insensitive direct match then trying a case insenstive contains match.
	/// </summary>
	/// <param name="selectElement">The SelectElement to use.</param>
	/// <param name="searchText">The text to find in the options.</param>
	public static void SelectByText(this SelectElement selectElement, string searchText)
	{
		var allOptionsThatHaveText =
			selectElement.Options.Where(se => se.Text.Equals(searchText, StringComparison.OrdinalIgnoreCase));
		if (allOptionsThatHaveText.Any())
		{
			foreach (var option in allOptionsThatHaveText)
			{
				option.Click();
			}
			return;
		}
		var optionWithText = selectElement.Options.Where(option => option.Text.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0);
		if (optionWithText.Any())
		{
			foreach (var option in optionWithText)
			{
				option.Click();
			}
			return;
		}
		
		throw new NoSuchElementException(string.Format("Cannot find the text: {0} by either a case insenstive match or a case insensitive equals match.", searchText));
	}
