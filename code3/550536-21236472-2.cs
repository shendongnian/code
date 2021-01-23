        public class EquatableList<T> : List<T>, IEquatable<EquatableList<T>> where T : IEquatable<T>
        {
            /// <summary>
            /// True, if this contains element with equal property-values
            /// </summary>
            /// <param name="element">element of Type T</param>
            /// <returns>True, if this contains element</returns>
            public new Boolean Contains(T element)
            {
                foreach (T t in this) if (t.Equals(element)) return true;
    
                return false;
            }
    
            /// <summary>
            /// True, if list is equal to this
            /// </summary>
            /// <param name="list">list</param>
            /// <returns>True, if instance euqals list</returns>
            public Boolean Equals(EquatableList<T> list)
            {
                if (list == null) return false;
    
                foreach (T t in this) if (!list.Contains(t)) return false;
    
                foreach (T t in list) if (!this.Contains(t)) return false;
    
                return true;
    
            }
        }
    }
