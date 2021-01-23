    var tmsd = new List<TmsData>();
    foreach (DataRow dr in dt.Rows)
    {
    m_firstname = dr["FirstName"].ToString();
    m_lastname = dr["LastName"].ToString();
    tmsd.Add(new TmsData() { FirstName = m_firstname, LastName = m_lastname} );
    }
    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    string m_json = serializer.Serialize(tmsd);
    return m_json;
