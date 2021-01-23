    int count = 0;
    foreach (string name : m_nameList)
    {
        if (string.IsNullOrEmpty(name))
        {
            count++;
        }
    }
    return count;
