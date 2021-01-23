    public static void SerializeAsXml(object gp, string target)
    {
        XmlSerializer xmlSel = new XmlSerializer(gp.GetType());
        using (TextWriter txtStream = new StreamWriter(target))
            xmlSel.Serialize(txtStream, gp);
    }
