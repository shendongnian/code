    class ArrayQueue<T>
    {
      private T[] backingStore ;
      private int head ; // offset to head of the queue (least recently added item)
      private int tail ; // offset to tail of the queue (most recently added item)
      
      /// <summary>
      /// current queue length
      /// </summary>
      public int Length   { get ; private set ; }
      /// <summary>
      /// Maximum Queue Length
      /// </summary>
      public int Capacity { get { return this.backingStore.Length ; } }
      
      /// <summary>
      /// Add an item to the queue
      /// </summary>
      /// <param name="value"></param>
      public void Enqueue( T value )
      {
        
        if ( Length == 0 )
        {
          this.backingStore[0] = value ;
          this.head  = 0 ;
          this.tail  = 0 ;
        }
        else
        {
          // A head/tail collision means the queue is full: throw an overflow exception
          if ( this.tail == this.head ) { throw new OverflowException("Maximum capacity exceeded") ; }
          this.backingStore[this.tail] = value ;
        }
        
        // increment the tail and the length, wrapping the tail point if necessary
        this.tail = (this.tail+1) % this.backingStore.Length ;
        ++this.Length ;
        
        return ;
      }
      
      /// <summary>
      /// Remove the next (oldest) item from the queue
      /// </summary>
      /// <returns></returns>
      public T Dequeue()
      {
        if ( this.Length < 1 ) { throw new InvalidOperationException("queue is empty") ; }
        
        T value = this.backingStore[head] ;
        this.backingStore[head] = default(T) ; // lose the reference so the newly dequeued item can be garbage-collected.
        
        --this.Length;
        this.head = (this.head+1) % this.backingStore.Length ;
        
        return value ;
      }
      
      /// <summary>
      /// Examine the head of the queue, without removing it
      /// </summary>
      /// <returns></returns>
      public T Peek()
      {
        if ( this.Length < 1 ) {  throw new InvalidOperationException("queue is empty") ; }
        
        T value = this.backingStore[head] ;
        return value ;
      }
      
      /// <summary>
      /// Clear/Empty the queue
      /// </summary>
      public void Clear()
      {
        // clear any object references to the queue so they can be garbage-collected
        Array.Clear(this.backingStore,0,this.backingStore.Length);
        this.head   = 0 ;
        this.tail   = 0 ;
        this.Length = 0 ;
        return ;
      }
      
      /// <summary>
      /// indicates whether or not the specified item is present in the queue
      /// </summary>
      /// <param name="value"></param>
      /// <returns></returns>
      public bool Contains( T value )
      {
        bool found = false ;
        for ( int i = 0 ; !found && i < this.Length ; ++i )
        {
          int p = (this.head+1) % this.Capacity ;
          found = this.backingStore[p].Equals( value ) ;
        }
        return found ;
      }
      
      /// <summary>
      /// Create an instance of an ArrayQueue&lt;T&gt; having the specified fixed capacity
      /// </summary>
      /// <param name="capacity"></param>
      /// <returns></returns>
      public static ArrayQueue<T> CreateInstance( int capacity )
      {
        if ( capacity < 0 ) throw new ArgumentOutOfRangeException("capacity","capacity must be non-negative");
        
        ArrayQueue<T> instance = new ArrayQueue<T>(capacity) ;
        
        return instance ;
      }
      
      /// <summary>
      /// private (and only constructor)
      /// </summary>
      /// <param name="capacity"></param>
      private ArrayQueue( int capacity )
      {
        this.backingStore = new T[capacity] ;
        this.Clear() ;
        return ;
      }
      
    }
