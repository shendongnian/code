    using (var dataContext = GetDataContext())
            {
                var invoiceData = from i in dataContext.Invoices
                                  where i.InvoiceNumber == paymentData.InvoiceNumber
                                  select i;
                foreach(var invoice in invoiceData)
                {
                    decimal outPut;
                    if (Decimal.TryParse(paymentData.AmountPaid, out outPut))
                    {
                        invoice.AmtPaid = invoice.AmtPaid + Convert.ToDecimal(paymentData.AmountPaid);
                    }
                }
                dataContext.SubmitChanges();
            }
