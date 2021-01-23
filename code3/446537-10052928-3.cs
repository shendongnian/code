    int count = 0;
    foreach (string name in m_nameList)
    {
        if (string.IsNullOrEmpty(name))
        {
            count++;
        }
    }
    return count;
