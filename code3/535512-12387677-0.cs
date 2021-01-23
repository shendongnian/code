        class RedBluePair<T1, T2>
        {
            private T1 _Red;
            private T2 _Blue;
            public RedBluePair(T1 red, T2 blue)
            {
                _Red = red;
                _Blue = blue;
            }
            
            public T1 Red { get { return _Red;} }
            
            public T2 Blue { get { return _Blue;} }
        }
