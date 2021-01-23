     var viewModels = new List<MyViewModel>();
     foreach(var item in dt.Rows)
     {
          var vm = new MyViewModel();
          vm.UserId = item["UserId"];
          vm.Punches = item["Punches"];
          vm.Date = DateTime.Parse(item["Date"]);
          //....
          viewModels.Add(vm);
     }
     dg.DataContext = viewModels;
