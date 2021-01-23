    public Dictionary<int, T> GetComponentType<T>() where T: IComponent
    {
        Dictionary<int, T> components = new Dictionary<int, T>();
    
        foreach (KeyValuePair<int, Entity> pair in m_allEntities)
        {
            foreach (IComponent c in m_entityComponents[m_allEntities[pair.Key]])
            {
                if (c is T)
                    components.Add(pair.Key, (T)c);
            }
        }
    
        return components;
    }
