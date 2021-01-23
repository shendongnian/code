    /// <summary>
    /// Add a new category to the list of available categories
    /// </summary>
    /// <param name="newCat">The category object to add</param>
    public void AddCategory( Category newCat )
    {
        // Ensure that the category doesn't already exist in the list
        if( this.m_CategoryList.Contains( newCat ) == false )
        {
            // Add the new category to the list
            this.m_CategoryList.Add( newCat );
        }
    }
    
    /// <summary>
    /// Remove a category to the list of available categories
    /// </summary>
    /// <param name="catName">The name of the category to be removed</param>
    public void RemoveCategory( string catName )
    {
        Category toRemove = null;
    
        // Iterate through the categories looking for a match
        foreach( Category cat in this.m_CategoryList)
        {
            // Compare the category names (case insensitive)
            if( cat.Name.ToUpper() == catName.ToUpper() )
            {
                // Assign the category to remove to a local variable and exit the loop
                toRemove = cat;
                break;
            }
        }
    
        // Remove the category if it's been located
        if( toRemove != null )
        {
            this.m_CategoryList.Remove( toRemove );
        }
    }
