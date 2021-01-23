    public void ManageDuplicateAlarm(string alertName, int dupValue)
    {
       try
       {
          int indx = m_alerts.Find(alertName);
          if (indx >= 0 && m_tblAlert.Rows.Count > indx)
          {
             DataRow row = m_tblAlert.Rows[idx];
             m_dcDuplicates.ReadOnly = false;
             row[m_dcDuplicates] = dupValue;
             m_dcDuplicates.ReadOnly = true;
          }
       }
     
