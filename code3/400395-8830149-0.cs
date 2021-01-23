    public string GetQuestionnaireName(int questionnaireId)
        {
            string returnValue = string.Empty;
            SqlCommand myCommand = new SqlCommand("GetQuestionnaireName", _productConn);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add(new SqlParameter("@QUEST_ID", SqlDbType.Int));
            myCommand.Parameters[0].Value = questionnaireId;
            SqlDataReader qName = getData(myCommand);
            while (qName.Read())
            {
               returnValue = qName[0].ToString();
            }
            _productConn.Close();
            return returnValue;
        }
