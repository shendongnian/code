    using (MemoryStream m = new MemoryStream())
    {
        formatter.Serialize(m, list);
        m.Flush();
        HiddenField1.Value = Convert.ToBase64String(m.ToArray());
    }
