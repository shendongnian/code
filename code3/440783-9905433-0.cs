    List<OleDbParameter> parameters = new List<OleDbParameter>();
                for (int i = 0; i < columnCounter; i++)
                {
                    postgresQuery.Append(string.Format("@Column{0}, ", i));
                    parameters.Add(new OleDbParameter(string.Format("@Column{0}, ", i), oleDataBaseConnection.GetFieldById(i));
                }
