    public interface IMemberInfo
    {
        MemberInfo Wrapped { get; }
        object GetValue( object obj );
        void SetValue( object obj, object value );
    }
    internal abstract class MemberInfoWrapper : IMemberInfo
    {
        protected readonly MemberInfo MemberInfo;
        public MemberInfoWrapper( MemberInfo memberInfo )
        {
            MemberInfo = memberInfo;
        }
        public abstract object GetValue( object obj );
        public abstract void SetValue( object obj, object value );
     
        public virtual MemberInfo Wrapped
        {
            get { return MemberInfo; }
        }
    }
    internal class PropertyInfoWrapper : MemberInfoWrapper
    {
        public PropertyInfoWrapper( MemberInfo propertyInfo ) : base( propertyInfo )
        {
            Debug.Assert( propertyInfo is PropertyInfo );
        }
        public override object GetValue( object obj )
        {
            return ( (PropertyInfo)MemberInfo ).GetValue( obj, null );
        }
        public override void SetValue( object obj, object value )
        {
            ( (PropertyInfo)MemberInfo ).SetValue( obj, value, null );
        }
    }
    internal class FieldInfoWrapper : MemberInfoWrapper
    {
        public FieldInfoWrapper( MemberInfo fieldInfo ) : base( fieldInfo )
        {
            Debug.Assert( fieldInfo is FieldInfo );
        }
        public override object GetValue( object obj )
        {
            return ( (FieldInfo)MemberInfo ).GetValue( obj );
        }
        public override void SetValue( object obj, object value )
        {
            ( (FieldInfo)MemberInfo ).SetValue( obj, value );
        }
    }
