        [HttpGet]
        [Route("report/{scheduleId:int}")]
        public HttpResponseMessage DownloadReport(int scheduleId)
        {
            var reportStream = GenerateExcelReport(scheduleId);
            var result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(reportStream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "Schedule Report.xlsx"
            };
            return result;
        }
