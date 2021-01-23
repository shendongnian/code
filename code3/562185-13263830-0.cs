    class SafeActionSet
    {
        Object _sync = new Object();
        List<Action> _actions = new List<Action>(); //The main store
        List<Action> _delta = new List<Action>();   //Temporary buffer for storing added values while the main store is being enumerated
        int _lock = 0; //The number of concurrent Invoke enumerations
        public void Add(Action action)
        {
            lock(sync)
            {
                if (0 == _lock)
                { //_actions list is not being enumerated and can be modified
                    _actions.Add(action);
                }
                else
                { //_actions list is being enumerated and cannot be modified
                    _delta.Add(action); //Storing the new values in the _delta buffer
                }
            }
        }
        public void Invoke()
        {
            lock(sync)
            {
                if (0 < _delta.Count)
                { //Re-entering Invoke after calling Add:  Invoke->Add,Invoke
                    Debug.Assert(0 < _lock);
                    var newActions = new List<Action>(_actions); //Creating a new list for merging delta
                    newActions.AddRange(_delta); //Merging the delta
                    _delta.Clear();
                    _actions = newActions; //Replacing the original list (which is still being iterated)
                }
                ++_lock;
            }
            foreach (var action in _actions)
            {
                action();
            }
            lock(sync)
            {
                --_lock;
                if ((0 == _lock) && (0 < _delta.Count))
                {
                    _actions.AddRange(_delta); //Merging the delta
                    _delta.Clear();
                }
            }
        }
    }
