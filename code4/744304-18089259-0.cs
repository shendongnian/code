		/// <summary>
		/// Gets a select list from an enum.
		/// </summary>
		/// <param name="enumObject">The enum object.</param>
		/// <returns></returns>
		public static SelectList ToSelectList(this Enum enumObject)
		{
			List<KeyValuePair<string, string>> selectListItemList = null;
			SelectList selectList = null;
			try
			{
				// Cast the enum values to strings then linq them into a key value pair we can use for the select list.
				selectListItemList = Enum.GetNames(enumObject.GetType()).Cast<string>().Select(item => { return new KeyValuePair<string, string>(item, item.PascalCaseToReadableString()); }).ToList();
				// Remove default value of Enum. This is handled in the editor template with the optionLabel argument.
				selectListItemList.Remove(new KeyValuePair<string, string>("None", "None"));
				// Build the select list from it.
				selectList = new SelectList(selectListItemList, "key", "value", enumObject);
			}
			catch (Exception exception)
			{
				Functions.LogError(exception);
			}
			return selectList;
		}
