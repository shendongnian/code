       public ActionResult Downloadexcel()
        {   
			var Emplist = JsonConvert.SerializeObject(dbcontext.Employees.ToList());
			DataTable dt11 = (DataTable)JsonConvert.DeserializeObject(Emplist, (typeof(DataTable)));
            dt11.TableName = "Emptbl";
            FileContentResult robj;
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt11);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    var bytesdata = File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "myFileName.xlsx");
                    robj = bytesdata;
                }
            }
            
            return Json(robj, JsonRequestBehavior.AllowGet);
        }
