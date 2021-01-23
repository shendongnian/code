    ConcurrentQueue<T> Queue = new ConcurrentQueue<T>();
    
    void onClick()
    {
      Queue.Enqueue(theClickedNote);
      
      // start Play on another thread if necessary
    }
    
    void Play()
    {
      if (Playing) return;
    
      Note note;
      while(Queue.TryDequeue(out note))
      {
         note.Play();
      }
    }
