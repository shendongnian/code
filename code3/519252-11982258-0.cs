        public ReportClass ConfigureReportClass(string strReportPath, object[] objParameters)
        {
            ReportClass rptH = new ReportClass();
            rptH.FileName = strReportPath;
            int Count = 0;
            rptH.Load();
            rptH.SetDatabaseLogon("myusername", "mypassword");
            try
            {
                if (objParameters == null)
                    return rptH;
                foreach (object obj in objParameters)
                {
                    ParameterField param = rptH.ParameterFields[Count++];  // first param 
                    param.AllowCustomValues = true;
                    ParameterDiscreteValue Disparam = new ParameterDiscreteValue();
                    Disparam.Value = obj;
                    param.CurrentValues.Add(Disparam);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rptH;
        }
