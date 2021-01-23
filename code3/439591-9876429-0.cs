        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.ContentType = "application/json";
            DataSet results = new DataSet();
            results = widgetsBLObject.selectTheWidgets();
            string jsresults = MyClassLibrary.JqueryTools.GetJSONString(results.Tables[0]);
            return jsresults;
        }
