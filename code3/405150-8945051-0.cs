    public static void Remove(Keys _key)
    {
        Contract.Ensures(m_usedKeys.Any(x => x == _key));        
        m_usedKeys.Remove(_key);
    }
