    XmlSerializer ser = new XmlSerializer(typeof(DataTable));
    DataTable dt = new DataTable("data");
    TextWriter writer = new StreamWriter(Application.StartupPath+"\\"+fname+".xml");
    ser.Serialize(writer, dt);
    writer.Close();
