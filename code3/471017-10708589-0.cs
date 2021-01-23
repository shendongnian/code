    public struct Group
    {
        #region Code that is to be configured
        public static readonly Group Alpha = new Group("Group Alpha");
        public static readonly Group Beta = new Group("Group Beta");
        public static readonly Group Invalid = new Group("N/A");
    
    
        public static IEnumerable<Group> AllGroups
        {
            get
            {
                yield return Alpha;
                yield return Beta;
                yield return Invalid;
                //...
                //add a yield return for all instances here.
            }
        }
    
        #endregion
        private string value;
    
        /// <summary>
        /// default constructor
        /// </summary>
        //private Group()
        //{
        //    //you can make this default value whatever you want.  null is another option I considered, but you 
        //    //shouldn't have this me anything that doesn't exist as one of the options defined at the top of 
        //    //the page.
        //    value = "N/A";
        //}
        /// <summary>
        /// primary constructor
        /// </summary>
        /// <param name="value">The string value that this is a wrapper for</param>
        private Group(string value)
        {
            this.value = value;
        }
    
        /// <summary>
        /// Compares the Group to another group, or to a string value.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Group)
            {
                return this.value.Equals(((Group)obj).value);
            }
    
            string otherString = obj as string;
            if (otherString != null)
            {
                return this.value.Equals(otherString);
            }
    
            throw new ArgumentException("obj is neither a Group nor a String");
        }
    
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    
        /// <summary>
        /// returns the internal string that this is a wrapper for.
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public static implicit operator string(Group group)
        {
            return group.value;
        }
    
        /// <summary>
        /// Parses a string and returns an instance that corresponds to it.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Group Parse(string input)
        {
            return AllGroups.Where(item => item.value == input).FirstOrDefault();
        }
    
        /// <summary>
        /// Syntatic sugar for the Parse method.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public static explicit operator Group(string other)
        {
            return Parse(other);
        }
    
        public override string ToString()
        {
            return value;
        }
    }
