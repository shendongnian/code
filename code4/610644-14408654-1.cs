    public ActionResult Index()
    {
        SqlCommand cmd = new SqlCommand("SELECT [disease_id], [disease], [remedy] FROM disease", m_DBCon);
        m_Reader = cmd.ExecuteReader();
        List<DiseaseResult> record = new List<DiseaseResult>();
        while (m_Reader.Read())
        {
            record.Add(new DiseaseResult() { DiseaseId = m_Reader[0], Disease = m_Reader[1], Remedy = m_Reader[2]);
        }
        return View(record);
    }
