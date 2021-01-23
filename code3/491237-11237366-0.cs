        [AcceptVerbs(HttpVerbs.Post)]
                public ActionResult uploadFile(string fileName, string fileBytes)
                {
                    if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(fileBytes))
                        return Json(new { status = "Error" }, JsonRequestBehavior.AllowGet);
        
                    string[] byteToConvert = fileBytes.Split('.');
                    List<byte> fileBytesList = new List<byte>();
        
                    byteToConvert.ToList<string>().ForEach(x => fileBytesList.Add(Convert.ToByte(x)));
        
                    //Now you can save the bytes list to a file
                    
                    return Json(new { status = "Success" }, JsonRequestBehavior.AllowGet);
                }
