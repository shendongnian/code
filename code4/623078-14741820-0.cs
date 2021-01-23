    [HttpPost]
    public ActionResult SomeImporter(HttpPostedFileBase attachment, FormCollection formCollection, string submitButton, string fileName
    {
        if (submitButton.Equals("Import"))
        {
            byte[] fileBytes = ImportData(fileName, new CompanyExcelColumnData());
            if (fileBytes != null)
            {
                return File(
                    fileBytes,
                    "application/ms-excel",
                    string.Format("Filexyz {0}", DateTime.Now.ToString("yyyyMMdd HHmm")));
            }
            return View();
        }
        throw new ArgumentException("Value not valid", "submitButton");
    }
