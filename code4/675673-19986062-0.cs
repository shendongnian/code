    try
            {
                Excel.Application application;
                Excel.Workbook workBook;
                Excel.Worksheet workSheet;
                object misValue = System.Reflection.Missing.Value;
    
                application = new Excel.ApplicationClass();
                workBook = application.Workbooks.Add(misValue);
                workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);
    
                int i = 1;
                workSheet.Cells[i, 2] = "MSS Close Sheet"; 
                WorkSheet.Cells[i, 2].Style.Font.Bold = true;               
                i++;
                workSheet.Cells[i, 2] = "MSS - " + dpsNoTextBox.Text;
                WorkSheet.Cells[i, 2].Style.Font.Bold = true;
                i++;
                workSheet.Cells[i, 2] = customerNameTextBox.Text;
                i++;                
                workSheet.Cells[i, 2] = "Opening Date : ";
                workSheet.Cells[i, 3] = openingDateTextBox.Value.ToShortDateString();
                i++;
                workSheet.Cells[i, 2] = "Closing Date : ";
                workSheet.Cells[i, 3] = closingDateTextBox.Value.ToShortDateString();
                i++;
                i++;
                i++;
    
                workSheet.Cells[i, 1] = "SL. No";
                workSheet.Cells[i, 2] = "Month";
                workSheet.Cells[i, 3] = "Amount Deposited";
                workSheet.Cells[i, 4] = "Fine";
                workSheet.Cells[i, 5] = "Cumulative Total";
                workSheet.Cells[i, 6] = "Profit + Cumulative Total";
                workSheet.Cells[i, 7] = "Profit @ " + profitRateComboBox.Text;
                WorkSheet.Cells[i, 1].EntireRow.Font.Bold = true;
                i++;
    
    
    
                /////////////////////////////////////////////////////////
                foreach (RecurringDeposit rd in RecurringDepositList)
                {
                    workSheet.Cells[i, 1] = rd.SN.ToString();
                    workSheet.Cells[i, 2] = rd.MonthYear;
                    workSheet.Cells[i, 3] = rd.InstallmentSize.ToString();
                    workSheet.Cells[i, 4] = "";
                    workSheet.Cells[i, 5] = rd.CumulativeTotal.ToString();
                    workSheet.Cells[i, 6] = rd.ProfitCumulative.ToString();
                    workSheet.Cells[i, 7] = rd.Profit.ToString();
                    i++;
                }
                //////////////////////////////////////////////////////
    
    
                ////////////////////////////////////////////////////////
                workSheet.Cells[i, 2] = "Total (" + RecurringDepositList.Count + " months installment)";
                WorkSheet.Cells[i, 2].Style.Font.Bold = true;
                workSheet.Cells[i, 3] = totalAmountDepositedTextBox.Value.ToString("0.00");
                i++;
    
                workSheet.Cells[i, 2] = "a) Total Amount Deposited";
                workSheet.Cells[i, 3] = totalAmountDepositedTextBox.Value.ToString("0.00");
                i++;
    
                workSheet.Cells[i, 2] = "b) Fine";
                workSheet.Cells[i, 3] = "";
                i++;
    
                workSheet.Cells[i, 2] = "c) Total Pft Paid";
                workSheet.Cells[i, 3] = totalProfitPaidTextBox.Value.ToString("0.00");
                i++;
    
                workSheet.Cells[i, 2] = "Sub Total";
                WorkSheet.Cells[i, 2].Style.Font.Bold = true;
                workSheet.Cells[i, 3] = (totalAmountDepositedTextBox.Value + totalProfitPaidTextBox.Value).ToString("0.00");
                i++;
    
                workSheet.Cells[i, 2] = "Deduction";
                WorkSheet.Cells[i, 2].Style.Font.Bold = true;
                i++;
    
                workSheet.Cells[i, 2] = "a) Excise Duty";
                workSheet.Cells[i, 3] = "0";
                i++;
    
                workSheet.Cells[i, 2] = "b) Income Tax on Pft. @ " + incomeTaxPercentageTextBox.Text;
                workSheet.Cells[i, 3] = "0";
                i++;
    
                workSheet.Cells[i, 2] = "c) Account Closing Charge ";
                workSheet.Cells[i, 3] = closingChargeCommaNumberTextBox.Value.ToString("0.00");
                i++;
    
                workSheet.Cells[i, 2] = "d) Outstanding on BAIM(FO) ";
                workSheet.Cells[i, 3] = baimFOLowerTextBox.Value.ToString("0.00");
                i++;
    
                workSheet.Cells[i, 2] = "Total Deduction ";
                WorkSheet.Cells[i, 2].Style.Font.Bold = true;
                workSheet.Cells[i, 3] = (incomeTaxDeductionTextBox.Value + closingChargeCommaNumberTextBox.Value + baimFOTextBox.Value).ToString("0.00");
                i++;
    
                workSheet.Cells[i, 2] = "Client Paid ";
                WorkSheet.Cells[i, 2].Style.Font.Bold = true;
                workSheet.Cells[i, 3] = customerPayableNumberTextBox.Value.ToString("0.00");
                i++;
    
                workSheet.Cells[i, 2] = "e) Current Balance ";
                workSheet.Cells[i, 3] = currentBalanceCommaNumberTextBox.Value.ToString("0.00");
                workSheet.Cells[i, 5] = "Exp. Pft paid on MSS A/C(PL67054)";
                workSheet.Cells[i, 6] = plTextBox.Value.ToString("0.00");
                i++;
    
                workSheet.Cells[i, 2] = "e) Total Paid ";
                workSheet.Cells[i, 3] = customerPayableNumberTextBox.Value.ToString("0.00");
                workSheet.Cells[i, 5] = "IT on Pft (BDT16216)";
                workSheet.Cells[i, 6] = incomeTaxDeductionTextBox.Value.ToString("0.00");
                i++;
    
                workSheet.Cells[i, 2] = "Difference";
                WorkSheet.Cells[i, 2].Style.Font.Bold = true;
                workSheet.Cells[i, 3] = (currentBalanceCommaNumberTextBox.Value - customerPayableNumberTextBox.Value).ToString("0.00");
                workSheet.Cells[i, 5] = "Account Closing Charge";
                workSheet.Cells[i, 6] = closingChargeCommaNumberTextBox.Value;
                i++;
    
                ///////////////////////////////////////////////////////////////
    
                workBook.SaveAs("D:\\" + dpsNoTextBox.Text.Trim() + "-" + customerNameTextBox.Text.Trim() + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                workBook.Close(true, misValue, misValue);
                application.Quit();
    
                releaseObject(workSheet);
                releaseObject(workBook);
                releaseObject(application);
