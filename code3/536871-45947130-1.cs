    namespace ExcelUploadFileDemo.Controllers
        {
            public class HomeController : Controller
            {
                public ActionResult Index()
                {
                    UploadFile UploadFile = new UploadFile();
                    return View(UploadFile);
                }
    
                [HttpPost]
                public ActionResult Index(UploadFile UploadFile)
                {
                    if (ModelState.IsValid)
                    {
    
                        if (UploadFile.ExcelFile.ContentLength > 0)
                        {
                            if (UploadFile.ExcelFile.FileName.EndsWith(".xlsx") || UploadFile.ExcelFile.FileName.EndsWith(".xls"))
                            {
                                XLWorkbook Workbook;
                                Try//incase if the file is corrupt
                                {
                                    Workbook = new XLWorkbook(UploadFile.ExcelFile.InputStream);
                                }
                                catch (Exception ex)
                                {
                                    ModelState.AddModelError(String.Empty, $"Check your file. {ex.Message}");
                                    return View();
                                }
                                IXLWorksheet WorkSheet = null;
                                Try//incase if the sheet you are looking for is not found
                                {
                                    WorkSheet = Workbook.Worksheet("sheet1");
    
                                }
                                catch
                                {
                                    ModelState.AddModelError(String.Empty, "sheet1 not found!");
                                    return View();
                                }
                                WorkSheet.FirstRow().Delete();//if you want to remove ist row
    
                                foreach (var row in WorkSheet.RowsUsed())
                                {
                                    //do something here
                                    row.Cell(1).Value.ToString();//Get ist cell. 1 represent column number
    
                                }
                            }
                            else
                            {
                                ModelState.AddModelError(String.Empty, "Only .xlsx and .xls files are allowed");
                                return View();
                            }
                        }
                        else
                        {
                            ModelState.AddModelError(String.Empty, "Not a valid file");
                            return View();
                        }
                    }
                    return View();
                }
            }
        }
