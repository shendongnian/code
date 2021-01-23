    private void printInvoicesButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] selection = this.ordersGridView.GetSelectedRows();
            XtraReport reportMerge = new XtraReport();
            reportMerge.CreateDocument();
            IList<XtraReport> reportList = new List<XtraReport>();
            // Create a report.
            //invoiceReport report = new invoiceReport();
            for (int j = 0; j < selection.Length; j++)
            {
                XtraReport report = new XtraReport();
                string filePath = @"Reports/invoiceReport1.repx";
                report.LoadLayout(filePath);
                InvoiceData invoice = new InvoiceData();
                for (int i = 0; i < DataRepository.Orders.Orders.Count; i++)
                {
                    if (
                        ordersGridView.GetRowCellValue(selection[j], "InvoiceCode").Equals(
                            DataRepository.Orders.Orders[i].InvoiceCode))
                    {
                        BindingSource dataSource = new BindingSource();
                        invoice = InvoiceData.AdaptFrom(DataRepository.Orders.Orders[i], DataRepository.Orders,
                                                        DataRepository.Products.Products,
                                                        DataRepository.ProductOptionMaster,
                                                        DataRepository.ProductOptionDataSet,
                                                        DataRepository.CustomerShippingAddresses,
                                                        DataRepository.Customers.UserMaster,
                                                        DataRepository.AttributesData.Product_Attributes);
                        dataSource.Add(invoice);
                        report.DataSource = dataSource;
                        //report.ShowPreview();
                        report.CreateDocument();
                    }
                }
                reportList.Add(report);
            }
            for(int i=0;i<reportList.Count;i++)
            {
                reportMerge.Pages.AddRange(reportList[i].Pages);
            }
            
            // Show the report's preview.
            reportMerge.ShowPreviewDialog();            
        }
