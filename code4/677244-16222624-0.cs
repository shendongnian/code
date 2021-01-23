    @if (vm.User.TotalSales != 0)
    {
        Html.TextBoxFor(vm => vm.User.TotalSales)
    }
    else{
        Html.TextBoxFor(vm => vm.User.TotalSales.Age, new { @Value = "" }) 
    }
