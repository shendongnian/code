          var startDate = DateTime.Parse("08/02/2008");
          var endDate = DateTime.Parse("08/07/2009");
          var resultDates=Enumerable.Range(0, 1 + endDate.Month - startDate.Month)
                .Select(startDate.AddMonths)
                .ToList();
