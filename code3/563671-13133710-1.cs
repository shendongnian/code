        public ActionResult ReportsGrid()
        {
            var reportService = new ReportService();
            //System.Data.DataTable dt = reportService.ExecuteQuery(query);
            return PartialView("ReportsGrid", new System.Data.DataTable());
        }
