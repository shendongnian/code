        public async Task<Event> GetEvent()
        {
            // Fill the _tasks first time we call the method.
            if (_tasks == null)
                _tasks = (from p in _providers select p.GetEvent()).ToArray();
            return await await Task<Event>.WhenAny(_tasks);
        }
