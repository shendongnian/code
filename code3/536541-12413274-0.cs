        /// <summary>
        /// Return true if two types or equal, or this type inherits from (or implements) the specified Type.
        /// Necessary since Type.IsSubclassOf returns false if they're the same type.
        /// </summary>
        public static bool IsSameOrSubclassOf(this Type t, Type other)
        {
            if (t == other)
            {
                return true;
            }
            if (other.IsInterface)
            {
                return t.GetInterface(other.Name) != null;
            }
            return t.IsSubclassOf(other);
        }
        and use it like below
        Type t = typeof(derivedFileType);
        if(t.IsSameOrSubclassOf(typeof(file)))
        { }
