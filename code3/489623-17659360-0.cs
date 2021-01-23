        int IVsUIHierarchy.AdviseHierarchyEvents(IVsHierarchyEvents eventSink, out uint cookie)
        {
            cookie = _sinkCookie++; // come up with some unique cookie
            _eventSinks.Add(cookie, eventSink); // remember this sink
            return VSConstants.S_OK;
        }
        int IVsUIHierarchy.UnadviseHierarchyEvents(uint cookie)
        {
            _eventSinks.Remove(cookie);
            return VSConstants.S_OK;
        }
