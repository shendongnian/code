    public ActionResult ShowReport(string URL)
        {
            string tableString = ""; 
            [Code to Create table called ReportTable and add rows etc]
            tableString = RenderControlToString(ReportTable );
            //ViewBag.Table= tableString; 
            return this.Content(tableString, "application/json");
        }
