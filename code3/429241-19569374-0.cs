    ViewportAxesRangeRestriction r = new ViewportAxesRangeRestriction
    {
      YRange = new DisplayRange(vm.MinTemp, vm.MaxTemp),
      XRange = new DisplayRange(DateTimeAxis.ConvertToDouble(vm.StartTime), DateTimeAxis.ConvertToDouble(vm.EndDate))
    };
