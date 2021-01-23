    List<entries> entriesToRemove = new List<entries>();
    foreach(entry in myContainer)
    {
        if ( someConditionIsMet )
        {
            entriesToRemove.Add(entry);
        } 
    }
    for ( int i = entriesToRemove.size() - 1; i > 0; --i )
    {
        myContainer.Remove(entriesToRemove[i]);
    }
    entriesToRemove.clear();
