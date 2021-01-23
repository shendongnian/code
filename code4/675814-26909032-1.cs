     public YearlyResourceReport GetYearlyOrders()
     {
        YearlyResourceReport yrr = new YearlyResourceReport();
        for(int i = 1; i <= 12; i++)
        {
            yrr.MonthlyResourceReports.Add(new MonthlyOrderInfo {
            moi.MonthNumber = i,
            moi.OrdersInfo = WorkOrderEntity.GetMonthlyOrders(year, i, loggedInUser, customerIds, sortBy).ToList()
            });
        }
        return result;
     }
