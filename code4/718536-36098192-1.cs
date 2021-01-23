    public void SetParameters(List<BusLib.Report.ReportParameter> pParams)
        {
            if (pParams == null) { return; }
            try
            {
                foreach (BusLib.Report.ReportParameter pPara in pParams)
                {
               	    CReport.SetParameterValue(pPara.ParameterName, pPara.ParameterValue);
                }
            }
            catch (Exception Ex)
            {
                Val.Message(Ex.Message.ToString());
            }
        }
