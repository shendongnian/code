    class MyUserType : ICompositeUserType
    {
        public object Assemble(object cached, ISessionImplementor session, object owner)
        {
            return DeepCopy(cached);
        }
        public object DeepCopy(object value)
        {
            return ((IList<TravellingChoice>)value).ToList();
        }
        public object Disassemble(object value, ISessionImplementor session)
        {
            return DeepCopy(value);
        }
        bool ICompositeUserType.Equals(object x, object y)
        {
            var list1 = x as IList<TravellingChoice>;
            var list2 = y as IList<TravellingChoice>;
            return (x == null) ? y == null : list1.SequenceEqual(list2);
        }
        public int GetHashCode(object x)
        {
            // example implementation
            var list = x as IList<TravellingChoice>;
            unchecked
            {
                return list == null ? 0 : list.Sum(choice => choice.GetHashCode());
            }
        }
        public object GetPropertyValue(object component, int property)
        {
            // TODO:
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
            return ((ISession)session).QueryOver<TravellingChoice>()
                .WhereRestrictionOn(choice => choice.Id).IsInG(ids)
                .List();
        }
        public void NullSafeSet(IDbCommand cmd, object value, int index, bool[] settable, NHibernate.Engine.ISessionImplementor session)
        {
            var list = value as IList<TravellingChoice>;
            NHibernateUtil.String.Set(cmd, string.Join(", ", list.Select(choice => choice.Id.ToString()).ToArray()), index);
        }
        public string[] PropertyNames
        {
            get { // TODO:; }
        }
        public IType[] PropertyTypes
        {
            get { return NHibernateUtil.; }
        }
        public object Replace(object original, object target, NHibernate.Engine.ISessionImplementor session, object owner)
        {
            return original;
        }
        public Type ReturnedClass
        {
            get { return typeof(TravellingChoice); }
        }
        public void SetPropertyValue(object component, int property, object value)
        {
            // TODO:
        }
    }
