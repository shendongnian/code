                string strPrinterAddress = "domain\machinename";
                objDoc = new BrssCom.Document();
                string strPath = "192.168.1.45" + " /D" + strPrinterAddress;
                if (objDoc.Open(strPath))
                {
                    objDoc.SetText(0, "Recycle: " + recycleReason);
                    
                    objDoc.SetText(1, "Other Text");
                    objDoc.SetBarcodeData(0, "1234");
                    objDoc.DoPrint(BrssCom.PrintOptionConstants.bpoAutoCut, "0");
                }
