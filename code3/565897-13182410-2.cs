    public struct StringEnum
    {
        #region Code that is to be configured
        //For each value to be publicly exposed add a new field.
        public static readonly StringEnum Alpha = new StringEnum("Alpha Value");
        public static readonly StringEnum Beta = new StringEnum("Beta Value");
        public static readonly StringEnum Invalid = new StringEnum("Invalid");
    
    
        public static IEnumerable<StringEnum> AllValues
        {
            get
            {
                yield return Alpha;
                yield return Beta;
                yield return Invalid;
                //...
                //add a yield return for all instances here.
    
                //TODO refactor to use reflection so it doesn't need to be manually updated.
            }
        }
    
        #endregion
        private string value;
    
        /// <summary>
        /// default constructor
        /// </summary>
        //private Group()
        //{
        //    //You can make this default value whatever you want.  null is another option I considered 
        //    //(if this is a class an not a struct), but you 
        //    //shouldn't have this be anything that doesn't exist as one of the options defined at the top of 
        //    //the page.
        //    value = "Invalid";
        //}
        /// <summary>
        /// primary constructor
        /// </summary>
        /// <param name="value">The string value that this is a wrapper for</param>
        private StringEnum(string value)
        {
            this.value = value;
        }
    
        /// <summary>
        /// Compares the StringEnum to another StringEnum, or to a string value.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is StringEnum)
            {
                return this.Equals((StringEnum)obj);
            }
    
            string otherString = obj as string;
            if (otherString != null)
            {
                return this.Equals(otherString);
            }
    
            throw new ArgumentException("obj is neither a StringEnum nor a String");
        }
    
        /// <summary>
        /// Strongly typed equals method.
        /// </summary>
        /// <param name="other">Another StringEnum to compare this object to.</param>
        /// <returns>True if the objects are equal.</returns>
        public bool Equals(StringEnum other)
        {
            return value == other.value;
        }
    
        /// <summary>
        /// Equals method typed to a string.
        /// </summary>
        /// <param name="other">A string to compare this object to.  
        /// There must be a Group associated with that string.</param>
        /// <returns>True if 'other' represents the same Group as 'this'.</returns>
        public bool Equals(string other)
        {
            return value == other;
        }
    
        /// <summary>
        /// Overridden equals operator, for convenience.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>True if the objects are equal.</returns>
        public static bool operator ==(StringEnum first, StringEnum second)
        {
            return object.Equals(first, second);
        }
    
        public static bool operator !=(StringEnum first, StringEnum second)
        {
            return !object.Equals(first, second);
        }
    
        /// <summary>
        /// Properly overrides GetHashCode so that it returns the hash of the wrapped string.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    
        /// <summary>
        /// returns the internal string that this is a wrapper for.
        /// </summary>
        /// <param name="stringEnum"></param>
        /// <returns></returns>
        public static implicit operator string(StringEnum stringEnum)
        {
            return stringEnum.value;
        }
    
        /// <summary>
        /// Parses a string and returns an instance that corresponds to it.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static StringEnum Parse(string input)
        {
            return AllValues.Where(item => item.value == input).FirstOrDefault();
        }
    
        /// <summary>
        /// Syntatic sugar for the Parse method.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public static explicit operator StringEnum(string other)
        {
            return Parse(other);
        }
    
        /// <summary>
        /// A string representation of this object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return value;
        }
    }
