    public class ColorType : ICompositeUserType
    {
        /// <summary>
        /// Get the value of a property
        /// </summary>
        /// <param name="component">an instance of class mapped by this "type"</param>
        /// <param name="property"/>
        /// <returns>
        /// the property value
        /// </returns>
        public object GetPropertyValue(object component, int property)
        {
            var color = (Color) component;
            if (property == 0)
            {
                return color.ToArgb();
            }
            return (int) color.ToKnownColor();
        }
        /// <summary>
        /// Set the value of a property
        /// </summary>
        /// <param name="component">an instance of class mapped by this "type"</param>
        /// <param name="property"/>
        /// <param name="value">the value to set</param>
        public void SetPropertyValue(object component, int property, object value)
        {
            throw new InvalidOperationException("Color is immutable");
        }
        /// <summary>
        /// Compare two instances of the class mapped by this type for persistence
        ///             "equality", ie. equality of persistent state.
        /// </summary>
        /// <param name="x"/><param name="y"/>
        /// <returns/>
        public new bool Equals(object x, object y)
        {
            return ReferenceEquals(x, y) ||
                   x != null && y != null &&
                   object.Equals(x, y);
        }
        /// <summary>
        /// Get a hashcode for the instance, consistent with persistence "equality"
        /// </summary>
        public int GetHashCode(object x)
        {
            return x == null
                       ? 0
                       : x.GetHashCode();
        }
        /// <summary>
        /// Retrieve an instance of the mapped class from a IDataReader. Implementors
        ///             should handle possibility of null values.
        /// </summary>
        /// <param name="dr">IDataReader</param>
        /// <param name="names">the column names</param>
        /// <param name="session"/>
        /// <param name="owner">the containing entity</param>
        /// <returns/>
        public object NullSafeGet(IDataReader dr, string[] names,
            ISessionImplementor session, object owner)
        {
            var argb = (int?) NHibernateUtil.Int32.NullSafeGet(dr, names[0]);
            var knownColor = (int?) NHibernateUtil.Int32.NullSafeGet(dr, names[1]);
            return knownColor != null
                ? Color.FromKnownColor((KnownColor) knownColor.Value)
                : Color.FromArgb(argb.Value);
        }
        /// <summary>
        /// Write an instance of the mapped class to a prepared statement.
        ///             Implementors should handle possibility of null values.
        ///             A multi-column type should be written to parameters starting from index.
        ///             If a property is not settable, skip it and don't increment the index.
        /// </summary>
        /// <param name="cmd"/>
        /// <param name="value"/>
        /// <param name="index"/>
        /// <param name="settable"/>
        /// <param name="session"/>
        public void NullSafeSet(IDbCommand cmd, object value, int index,
            bool[] settable, ISessionImplementor session)
        {
            var color = (Color) value;
            if (color.IsKnownColor)
            {
                ((IDataParameter) cmd.Parameters[index]).Value = DBNull.Value;
                ((IDataParameter) cmd.Parameters[index + 1]).Value = (int) color.ToKnownColor();
            }
            else
            {
                ((IDataParameter) cmd.Parameters[index]).Value = color.ToArgb();
                ((IDataParameter) cmd.Parameters[index + 1]).Value = DBNull.Value;
            }
        }
        /// <summary>
        /// Return a deep copy of the persistent state, stopping at entities and at collections.
        /// </summary>
        /// <param name="value">generally a collection element or entity field</param>
        /// <returns/>
        public object DeepCopy(object value)
        {
            return value;
        }
        /// <summary>
        /// Transform the object into its cacheable representation.
        ///             At the very least this method should perform a deep copy.
        ///             That may not be enough for some implementations, 
        ///             method should perform a deep copy. That may not be enough for 
        ///             some implementations, however; for example, associations must 
        ///             be cached as identifier values. (optional operation)
        /// </summary>
        /// <param name="value">the object to be cached</param>
        /// <param name="session"/>
        /// <returns/>
        public object Disassemble(object value, ISessionImplementor session)
        {
            return value;
        }
        /// <summary>
        /// Reconstruct an object from the cacheable representation.
        ///             At the very least this method should perform a deep copy. (optional operation)
        /// </summary>
        /// <param name="cached">the object to be cached</param>
        /// <param name="session"/>
        /// <param name="owner"/>
        /// <returns/>
        public object Assemble(object cached, ISessionImplementor session, object owner)
        {
            return cached;
        }
        /// <summary>
        /// During merge, replace the existing (target) value in the entity we are merging to
        ///             with a new (original) value from the detached entity we are merging. For immutable
        ///             objects, or null values, it is safe to simply return the first parameter. For
        ///             mutable objects, it is safe to return a copy of the first parameter. However, since
        ///             composite user types often define component values, it might make sense to recursively
        ///             replace component values in the target object.
        /// </summary>
        public object Replace(object original, object target, ISessionImplementor session, object owner)
        {
            return original;
        }
        /// <summary>
        /// Get the "property names" that may be used in a query.
        /// </summary>
        public string[] PropertyNames { get { return new[] {"Argb", "KnownColor"}; } }
        /// <summary>
        /// Get the corresponding "property types"
        /// </summary>
        public IType[] PropertyTypes
        {
            get
            {
                return new IType[]
                       {
                           NHibernateUtil.Int32, NHibernateUtil.Int32
                       };
            }
        }
        /// <summary>
        /// The class returned by NullSafeGet().
        /// </summary>
        public Type ReturnedClass { get { return typeof (Color); } }
        /// <summary>
        /// Are objects of this type mutable?
        /// </summary>
        public bool IsMutable { get { return false; } }
    }
