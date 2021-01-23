    public class EquatableByValuesMixin<[BindToTargetType]T> : Mixin<T>, IEquatable<T> where T : class
        {
            private static readonly FieldInfo[] m_TargetFields = typeof(T).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
    
            bool IEquatable<T>.Equals(T other)
            {
                if (other == null)
                    return false;
                if (Target.GetType() != other.GetType())
                    return false;
                for (int i = 0; i < m_TargetFields.Length; i++)
                {
                    object thisFieldValue = m_TargetFields[i].GetValue(Target);
                    object otherFieldValue = m_TargetFields[i].GetValue(other);
    
                    if (!Equals(thisFieldValue, otherFieldValue))
                        return false;
                }
                return true;
            }
    
            [OverrideTarget]
            public new bool Equals(object other)
            {
                return ((IEquatable<T>)this).Equals(other as T);
            }
    
            [OverrideTarget]
            public new int GetHashCode()
            {
                int i = 0;
                foreach (FieldInfo f in m_TargetFields)
                    i ^= f.GetValue(Target).GetHashCode();
                return i;
            }
        }
    
        public class EquatableByValuesAttribute : UsesAttribute
        {
            public EquatableByValuesAttribute()
                : base(typeof(EquatableByValuesMixin<>))
            {
    
            }
        }
