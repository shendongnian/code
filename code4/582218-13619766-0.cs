    public class MyThing
    {
        public delegate void MyEventHandler(object sender, MyEventArgs ea);
    
        private MyEventHandler _change;
        public event MyEventHandler Change
        {
           add 
          { 
              var previousChange = _change;
              _change += value; 
              if (previousChange == null)
              {
                 StartWatching();
              }
           }
           remove 
           { 
              _change -= value;
              if (_change == null) 
              {
                 StopWatching();
              }
           }
        }
    
        public void StartWatching()
        {
            ...
        }
    
        public void StopWatching()
        {
            ...
        }
    }
