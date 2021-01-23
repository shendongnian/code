    /// <summary>
    /// A distinct value counter, using reflection
    /// </summary>
    public class DistinctValueCounter<TListItem>
    {
        /// <summary>
        /// Gets or sets the associated list items
        /// </summary>
        private IEnumerable<TListItem> ListItems { get; set; }
    
        /// <summary>
        /// Constructs a new distinct value counter
        /// </summary>
        /// <param name="listItems">The list items to check</param>
        public DistinctValueCounter(IEnumerable<TListItem> listItems)
        {
            this.ListItems = listItems;
        }
    
        /// <summary>
        /// Gets the distinct values, and their counts
        /// </summary>
        /// <typeparam name="TProperty">The type of the property expected</typeparam>
        /// <param name="propertyName">The property name</param>
        /// <returns>A dictionary containing the distinct counts, and their count</returns>
        public Dictionary<TProperty, int> GetDistinctCounts<TProperty>(string propertyName)
        {
            var result = new Dictionary<TProperty, int>();
    
            // check if there are any list items
            if (this.ListItems.Count() == 0)
            {
                return result;
            }
    
            // get the property info, and check it exists
            var propertyInfo = this.GetPropertyInfo<TProperty>(this.ListItems.FirstOrDefault(), propertyName);
            if (propertyInfo == null)
            {
                return result;
            }
    
            // get the values for the property, from the list of items
            return ListItems.Select(item => (TProperty)propertyInfo.GetValue(item, null))
                .GroupBy(value => value)
                .ToDictionary(value => value.Key, value => value.Count());
        }
    
        /// <summary>
        /// Gets the property information, for a list item, by its property name
        /// </summary>
        /// <typeparam name="TProperty">The expected property type</typeparam>
        /// <param name="listItem">The list item</param>
        /// <param name="propertyName">The property name</param>
        /// <returns>The property information</returns>
        private PropertyInfo GetPropertyInfo<TProperty>(TListItem listItem, string propertyName)
        {
            // if the list item is null, return null
            if (listItem == null)
            {
                return null;
            }
    
            // get the property information, and check it exits
            var propertyInfo = listItem.GetType().GetProperty(propertyName);
            if (propertyInfo == null)
            {
                return null;
            }
    
            // return the property info, if it is a match
            return propertyInfo.PropertyType == typeof(TProperty) ? propertyInfo : null;
        }
    }
