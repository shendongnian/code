    /// <summary>
    /// Category object for logging
    /// </summary>
    public class Category
    {
        #region Private Members
        private bool	m_active;
        private string	m_name;
        private bool	m_excludeFromLogFile = false;
        #endregion
    
        /// <summary>
        /// Create a category and add it to the Logging category list
        /// </summary>
        /// <param name="name">The Name of the category</param>
        /// <param name="active">The active state of the category</param>
        /// <param name="exclude">If true any messages for this category will not be written to the log file</param>
        /// <param name="addedToList">If true then the new category will be added to the logging category list</param>
        public Category(string name, bool active, bool exclude, bool addedToList)
        {
            m_name = name;
            m_active = active;
            m_excludeFromLogFile = exclude;
                
            if(addedToList)
            {
                Log.GetInstance().AddCategory(this);
            }
        }
    
        #region Public Accessor Methods
            // .. Add accessors as required 
        #endregion
    }
