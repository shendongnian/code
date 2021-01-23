    HashSet<string> usbSNs = new HashSet<string>(m_AttachedUSB);
    List<int> txtOldIndices = new List<int>();
    // Remove existing items from USB set, note indices of old items in TXT list.
    for (int i = 0; i < m_CachedUSB.Length; i++)
    {
        if (!usbSNs.Remove(m_CachedUSB[i]))
            txtOldIndices.Add(i);
    }
    // At this point you may want to check usbSNs and txtOldIndices
    // have the same number of elements.
    // Overwrite old items in TXT list with remaining, new items in USB set.    
    foreach(var newSN in usbSNs)
    {
        m_CachedUSB[txtOldIndices[0]] = newSN;
        txtOldIndices.RemoveAt(0);
    }
