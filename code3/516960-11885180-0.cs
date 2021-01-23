        /// <summary>
        /// Sets the selected item by value.
        /// </summary>
        /// <param name="list">Drop down list to select value on</param>
        /// <param name="value">Value to select</param>
        public static void SetSelectedByValue(this DropDownList list, string value)
        {
            var listItem = list.Items.FindByValue(value);
            if (listItem != null)
            {
                list.SelectedIndex = list.Items.IndexOf(listItem);
            }
        }
