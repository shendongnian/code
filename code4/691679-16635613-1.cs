      var serialID = Convert.ToInt32(dgBillSerials.SelectedRows[0].Cells[0].Value);
                   var bills= BillsFromDatabase.Bills.Where(b => b.BillSerialID == serialID && (b.BillNumber>=txtFirstBillNumber.Value && b.BillNumber<=txtLastBillNumber.Value)).ToList();
                    
                  var reportInfoList = new List<ReportInfo>();
                   var reportProductList = new List<ReportProduct>();
                   var tmp1 =new ReportInfo();
                   var tmp2 = new ReportProduct();
                   foreach (var bill in bills)
                   {
                       tmp1= new ReportInfo()
                           {
                               Address = bill.Address,
                               BillAddress = bill.BillAddress,
                               BillNumber =bill.SerialNumber + bill.BillNumber.ToString(),
                               BillOwner = bill.OwnerType == "sirket" ? bill.PersonTitle : bill.Name,
                            //   Date = bill.BillDate,
                               MoneyWithText = "deneme",
                               PaymentType = bill.PaymentType,
                               TaxNumberIDNumber=bill.OwnerType=="sirket"?bill.TaxDepartment + " " + bill.TaxNumber:bill.NationalID,
                               OrderId = bill.ID,
                               Date = bill.BillDate
                           };
                       var products = BillsFromDatabase.Products.Where(p => p.BillID == bill.ID).ToList();
                       double sum = 0;
                       foreach (var product in products)
                       {
                           sum += product.Price;
                           reportProductList.Add(new ReportProduct()
                                                 {  
                                                     Price = product.Price,
                                                     ProductCode = product.ProductCode,
                                                    ProductInfo = product.ProductInfo,
                                                    Amount = Math.Round((product.Price/118)*100,2),
                                                    Tax =Math.Round( product.Price -((product.Price / 118) * 100),2),
                                                    OrderId = product.BillID
                                                    
                                                 });  
                       }
                       tmp1.MoneyWithText = Utils.MoneyToText(sum); 
                       reportInfoList.Add(tmp1);
                   }
                   FrmReportPreview preview = new FrmReportPreview(reportInfoList,reportProductList);
                   preview.Show();
