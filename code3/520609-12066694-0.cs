    public SQLArray[] SQLtoArray(SqlParameter[] parama)
        {
            if (parama != null)
            {
                SqlParameter[] param = parama;
                int lenght = param.Count();
                SQLArray[] unner = new SQLArray[lenght];
                for (int i = 0; i < lenght; i++)
                {
                    unner[i] = new SQLArray();
                    unner[i].ParamaterName = param[i].ParameterName;
                    unner[i].Paramatertype = param[i].SqlDbType;
                    unner[i].ParamaterDirection = param[i].Direction;
                    unner[i].ParamaterValue = param[i].Value.ToString();
                }
                return unner;
            }
            return null;
        }
