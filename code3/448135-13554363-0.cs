    public sealed class EnumExample
    {
        #region Delegate definitions
        /// <summary>
        /// This is an example of adding a method to the enum.  This delegate provides the 
        /// signature of the method.
        /// </summary>
        /// <param name="input">A parameter for the delegate</param>
        /// <returns>Specifies the return value, in this case a (possibly different) EnumExample</returns>
        private delegate EnumExample DoAction(string input);
        #endregion
        #region Enum instances
        /// <summary>
        /// Description of the element
        /// The static readonly makes sure that there is only one imutable instance of each.
        /// </summary>
        public static readonly EnumExample FIRST = new EnumExample(1, "Name of first value",    
               delegate(string input)
                  {
                      // do something with input to figure out what state comes next
                      return result;
                  }
        );
        ...
        #endregion
        #region Private members
        /// <summary>
        /// The string name of the enum
        /// </summary>
        private readonly string name;
        /// <summary>
        /// The integer ID of the enum
        /// </summary>
        private readonly int value;
        /// <summary>
        /// The method that is used to execute Act for this instance
        /// </summary>
        private readonly DoAction action;
        #endregion
        #region Constructors
        /// <summary>
        /// This constructor uses the default value for the action method
        /// 
        /// Note all constructors are private to prevent creation of instances by any other code
        /// </summary>
        /// <param name="value">integer id for the enum</param>
        /// <param name="name">string value for the enum</param>
        private EnumExample(int value, string name) : this (value, name, defaultAction)
        {
        }
        /// <summary>
        /// This constructor sets all the values for a single instance.
        /// All constructors should end up calling this one.
        /// </summary>
        /// <param name="value">the integer ID for the enum</param>
        /// <param name="name">the string value of the enum</param>
        /// <param name="action">the method used to Act</param>
        private EnumExample(int value, string name, DoAction action)
        {
            this.name = name;
            this.value = value;
            this.action = action;
        }
        #endregion
        #region Default actions
        /// <summary>
        /// This is the default action for the DoAction delegate
        /// </summary>
        /// <param name="input">The inpute for the action</param>
        /// <returns>The next Enum after the action</returns>
        static private EnumExample defaultAction(string input)
        {
            return FIRST;
        }
        #endregion
        ...
    }
