        class ParallelEvent<TEventArg> where TEventArg : EventArgs
        {
            private readonly EventHandler<TEventArg> _handler1;
            private readonly EventHandler<TEventArg>[] _moreHandlers;
            public ParallelEvent(EventHandler<TEventArg> handler1, params EventHandler<TEventArg>[] moreHandlers)
            {
                if (handler1 == null)
                    throw new ArgumentNullException("handler1");
                if (moreHandlers == null)
                    throw new ArgumentNullException("moreHandlers");
                _handler1 = handler1;
                _moreHandlers = moreHandlers;
            }
            public void Handler(Object sender, TEventArg args)
            {
                IAsyncResult[] asyncResults = new IAsyncResult[_moreHandlers.Length];
                for (int i = 0; i < _moreHandlers.Length; i++)
                    asyncResults[i] = _moreHandlers[i].BeginInvoke(sender, args, null, null);
                _handler1(sender, args);
                for (int i = 0; i < _moreHandlers.Length; i++)
                    _moreHandlers[i].EndInvoke(asyncResults[i]);
            }
        }
