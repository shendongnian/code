    [HttpPost]
        public ActionResult UploadCards(HttpPostedFileBase file, string sheetName, int ProductID)
        {
            IExcelDataReader excelReader = null;
            try
            {
                if (file == null || file.ContentLength == 0)
                    throw new Exception("The user not selected a file..");
                if (file.FileName.Trim().EndsWith(".xlsx"))
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(file.InputStream);
                else if (file.FileName.Trim().EndsWith(".xls"))
                    excelReader = ExcelReaderFactory.CreateBinaryReader(file.InputStream);
                else
                    throw new Exception("Not a excel file");
                cardsToUpdate = logic.getUpdateCards(excelReader.AsDataSet().Tables[sheetName], ProductID);
                foreach (var item in cardsToUpdate)
                {
                    if (db.Cards.ToList().Exists(x => x.SerialNumber == item.SerialNumber))
                        cardsToUpdate.Remove(item);
                }
                Session["InfoMsg"] = "Click Update to finish";
            }
            catch (Exception ex)
            {
                Session["ErrorMsg"] = ex.Message;
            }
            finally
            {
                excelReader.Close();
            }
            return View("viewUploadCards", cardsToUpdate);
        }  
