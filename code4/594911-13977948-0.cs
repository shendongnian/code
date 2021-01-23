    private List<KeyValuePair<String, Binding>> _savedBindings = new List<KeyValuePair<String, Binding>>();
    private delegate void InvokeSuspendBinding();
    public void SuspendBinding()
    {
        if (InvokeRequired)
        {
            Invoke(new InvokeSuspendBinding(SuspendBinding));
            return;
        }
        foreach (DictionaryEntry entry in ChildControls)
        {
    	    if (entry.Value is Control && ((Control)entry.Value).DataBindings.Count > 0)
            {
                for (Int32 i = 0; i < ((Control)entry.Value).DataBindings.Count; i++)
    	        {
                    _savedBindings.Add(new KeyValuePair<String, Binding>(entry.Key as String, ((Control)entry.Value).DataBindings[i]));
                    ((Control)entry.Value).DataBindings.RemoveAt(i);
    	        }
    	    }
        }
    }
    private delegate void InvokeResumeBinding();
    public void ResumeBinding()
    {
        if (InvokeRequired)
        {
            Invoke(new InvokeResumeBinding(ResumeBinding));
            return;
        }
        foreach (DictionaryEntry entry in ChildControls)
        {
            foreach (KeyValuePair<String, Binding> kvp2 in _savedBindings)
    	    {
                if (kvp2.Key.Equals(entry.Key))
                    ((Control)entry.Value).DataBindings.Add(kvp2.Value);
    	    }
        }
    
        _savedBindings.Clear();
    }
