    class Reader<T> { 
      private AutoResetEvent m_event;
      private Node<T> m_marker;
    
      void Go() {
        while(true) { 
          m_event.WaitOne();
          var current = m_marker.Next;
          while (current != null) { 
            if (current.IsMarker) { 
              // Found a new marker.  Always record the marker because it may 
              // be the last marker in the chain 
              m_marker = current;
            } else { 
              // Actually process the data 
              ProcessData(current.Data);
            }
            current = current.Next;
          }
        }
      }
    }
      
