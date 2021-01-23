	DataTable getListRow(DataTable dt, int intSndBCode, int intPostManSCode)
        {
            IEnumerable<DataRow> results = (from MyRows in dt.AsEnumerable()
                           where
                           MyRows.Field<int>("m_sndBCode") == intSndBCode
                           &&
                           MyRows.Field<int>("m_postManSCode") == intPostManSCode
                           select MyRows);
            DataTable dtNew = results.CopyToDataTable();
            return dtNew;
        }
