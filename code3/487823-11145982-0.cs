        private void DoAll(List<MyObj> lst)
        {
            foreach (MyObj o in lst)
            {
                _queuedRows.Enqueue(o);
            }
    
            if (_queuedRows.Any())
                DoSingle();
        }
