    class ReportParameter { }
    class ServerReport
    {
        public ReportParameter[] GetParameters()
        {
            Contract.Ensures(Contract.Result<ReportParameter[]>() != null && Contract.Result<ReportParameter[]>().Length > 0,
                Resource1.Oops);
            // here's some logic to build parameters array...
            return new ReportParameter[0];
        }
    }
