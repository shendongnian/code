    public class List1 : IEnumerable<string>, IEnumerable<object>
            {
                IEnumerator<object> IEnumerable<object>.GetEnumerator()
                {
                    return GetEnumerator();
                }
    
                public IEnumerator<string> GetEnumerator()
                {
                    throw new NotImplementedException();
                }
    
                IEnumerator IEnumerable.GetEnumerator()
                {
                    return GetEnumerator();
                }
            }
