    public class AssetHolder<T> : IDictionary<string , T>
      {
    
        Dictionary<string , T> dictionary;
    
        public AssetHolder()
        {
          dictionary = new Dictionary<string , T>( );
      }
    
        public void Add( string key , T value )
        {
          dictionary.Add( key , value );
        }
    
        public bool ContainsKey( string key )
        {
          throw new NotImplementedException( );
        }
    
        public ICollection<string> Keys
        {
          get { throw new NotImplementedException( ); }
        }
    
        public bool Remove( string key )
        {
          throw new NotImplementedException( );
        }
    
        public bool TryGetValue( string key , out T value )
        {
          throw new NotImplementedException( );
        }
    
        public ICollection<T> Values
        {
          get { throw new NotImplementedException( ); }
        }
    
        public T this[string key]
        {
          get
          {
            throw new NotImplementedException( );
          }
          set
          {
            throw new NotImplementedException( );
          }
        }
    
        public void Add( KeyValuePair<string , T> item )
        {
          throw new NotImplementedException( );
        }
    
        public void Clear( )
        {
          throw new NotImplementedException( );
        }
    
        public bool Contains( KeyValuePair<string , T> item )
        {
          throw new NotImplementedException( );
        }
    
        public void CopyTo( KeyValuePair<string , T>[ ] array , int arrayIndex )
        {
          throw new NotImplementedException( );
        }
    
        public int Count
        {
          get { throw new NotImplementedException( ); }
        }
    
        public bool IsReadOnly
        {
          get { throw new NotImplementedException( ); }
        }
    
        public bool Remove( KeyValuePair<string , T> item )
        {
          throw new NotImplementedException( );
        }
    
        IEnumerator<KeyValuePair<string , T>> IEnumerable<KeyValuePair<string , T>>.GetEnumerator( )
        {
          throw new NotImplementedException( );
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator( )
        {
          return dictionary.Values.GetEnumerator( );
        }
      }
