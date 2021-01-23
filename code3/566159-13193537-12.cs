        // NOTE: The parameter to this action MUST match the ID and Name parameters of the file input in the view;
        // if not, it won't bind.
        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase CSVFile)
        {
            try
            {
                if (CSVFile == null || String.IsNullOrWhiteSpace(CSVFile.FileName))
                    return Json("You must provide the path to your CSV file", "text/plain");
                if (!CSVFile.FileName.ToLower().Contains(".csv"))
                    return Json("You can only upload CSV files", "text/plain");
                Guid id = worker.BeginImport(dataReporistory, new StreamReader(CSVFile.InputStream));
 
                
                //return some JSON
                var json = new 
                {
                    ID = id,
                    name = CSVFile.FileName,
                    size = CSVFile.ContentLength
                };
                return Json(json, "text/plain");
            }
            catch (Exception e)
            {
                return Json(Utilities.DisplayExceptionMessage(e), "text/plain");
            }
        }
