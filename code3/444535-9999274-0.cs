    private double[] array; // Initialize this appropriately.
    public double Dequeue()
    {
      // Assume you use these functions properly, and avoid the exception checks.
      double obj = this._array[this._head];
      // No need to clean up after ourselves if used appropriately...
      //this._array[this._head] = default (T);
      // Still need to adjust the position in the queue.
      this._head = (this._head + 1) % this._array.Length;
      // May not need these either.
      //--this._size;
      //++this._version;
      return obj;
    }
    
    
    public void Enqueue(T item)
    {
      // Don't bother trying to resize if you know you don't ever need to.
      this._array[this._tail] = item;
      this._tail = (this._tail + 1) % this._array.Length;
      // Probably don't need these.
      //++this._size;
      //++this._version;
    }
Also, if you **really** want to squeeze out performance, see if you can find a slightly faster set of operations to accomplish the same goal as the head and tail adjustments.  You can also look at C#'s unchecked keyword to see if it is appropriate for your situation.
