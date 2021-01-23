    class MyUserType<TChoice> : ICompositeUserType
    {
        public object Assemble(object cached, ISessionImplementor session, object owner)
        {
            return DeepCopy(cached);
        }
        public object DeepCopy(object value)
        {
            return ((IList<TChoice>)value).ToList();
        }
        public object Disassemble(object value, ISessionImplementor session)
        {
            return DeepCopy(value);
        }
        bool ICompositeUserType.Equals(object x, object y)
        {
            var list1 = x as IList<TChoice>;
            var list2 = y as IList<TChoice>;
            return (x == null) ? y == null : list1.SequenceEqual(list2);
        }
        public int GetHashCode(object x)
        {
            // example implementation
            var list = x as IList<TChoice>;
            unchecked
            {
                return list == null ? 0 : list.Sum(choice => choice.GetHashCode());
            }
        }
        public object GetPropertyValue(object component, int property)
        {
            // the list has no properties to get
            throw new NotSupportedException();
        }
        public bool IsMutable
        {
            get { return true; }
        }
        public object NullSafeGet(IDataReader dr, string[] names, ISessionImplementor session, object owner)
        {
            var str = (string)NHibernateUtil.String.Get(dr, names[0]);
            IList<int> ids = str.Split(',').Select(id => int.Parse(id.Trim())).ToList();
            // HACK: assuming session also implements ISession
            return ((ISession)session).QueryOver<TChoice>()
                .WhereRestrictionOn(choice => choice.Id).IsInG(ids)
                .List();
        }
        public void NullSafeSet(IDbCommand cmd, object value, int index, bool[] settable, NHibernate.Engine.ISessionImplementor session)
        {
            var list = value as IList<TChoice>;
            NHibernateUtil.String.Set(cmd, string.Join(", ", list.Select(choice => choice.Id.ToString()).ToArray()), index);
        }
        public string[] PropertyNames
        {
            get { return new string[0]; }
        }
        public IType[] PropertyTypes
        {
            get { return new IType[0]; }
        }
        public object Replace(object original, object target, NHibernate.Engine.ISessionImplementor session, object owner)
        {
            return original;
        }
        public Type ReturnedClass
        {
            get { return typeof(TChoice); }
        }
        public void SetPropertyValue(object component, int property, object value)
        {
            // the list has no properties to set
            throw new NotSupportedException();
        }
    }
