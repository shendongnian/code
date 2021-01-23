    public void Add(T item){
          this.TryAddWithNoTimeValidation(item, -1, new CancellationToken());
    }
    
    public void Add(T item, CancellationToken cancellationToken){
          this.TryAddWithNoTimeValidation(item, -1, cancellationToken);
        }
    
    public bool TryAdd(T item){
          return this.TryAddWithNoTimeValidation(item, 0, new CancellationToken());
        }
    
    public bool TryAdd(T item, TimeSpan timeout){
          BlockingCollection<T>.ValidateTimeout(timeout);
          return this.TryAddWithNoTimeValidation(item, (int) timeout.TotalMilliseconds, new CancellationToken());
        }
    
    public bool TryAdd(T item, int millisecondsTimeout){
          BlockingCollection<T>.ValidateMillisecondsTimeout(millisecondsTimeout);
          return this.TryAddWithNoTimeValidation(item, millisecondsTimeout, new           CancellationToken());
    }
    
    public bool TryAdd(T item, int millisecondsTimeout, CancellationToken cancellationToken){
     BlockingCollection<T>.ValidateMillisecondsTimeout(millisecondsTimeout);
     return this.TryAddWithNoTimeValidation(item, millisecondsTimeout, cancellationToken);
    }
