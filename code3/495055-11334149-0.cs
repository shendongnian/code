            while (Reader.Read())
            {
                for (int i = 0; i < Convert.ToInt16(lognr); i++)
                {
                    logs = logs + (Reader.GetValue(i).ToString());  
                }
            }
