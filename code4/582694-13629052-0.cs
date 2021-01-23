    using (StreamWriter writer = new StreamWriter(m_fileName))
    {       
        XmlSerializer serializer = new XmlSerializer(typeof(Tube));
        serializer.Serialize(writer, m_tube);
        // Exception handling omitted for brevity
    }
    using (StreamWriter writer = new StreamWriter(m_fileName2))
    {
        XmlSerializer serializer2 = new XmlSerializer(typeof(Intersection ));
        serializer2.Serialize(writer, m_intersection);
        // Exception handling omitted for brevity
    }
