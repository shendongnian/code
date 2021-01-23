    public void GetMessage(object viewModel, bool isCheckMessages)
    {
      if (viewModel is AnnualReportWelComeViewModel)
      {
         var reportMessage = viewModel as AnnualReportWelComeViewModel;
         // ...
      }
      else if (viewModel is MonthlyReportWelComeViewModel)
      {
         var reportMessage = viewModel as MonthlyReportWelComeViewModel;
         // ...
      }
     
    }
