        MyDatatBaseDataContext MyDB = new MyDatatBaseDataContext();
         var _Udate_2 = MyDB.Employees.Where(u => (u.Address == "WestSreet"));
        foreach (var item in _Udate_2)
        {
            item.Address = "WS";
        }
        MyDB.SubmitChanges();
        var Select = from s in MyDB.Employees select s;
        grd_1.ItemsSource = Select;
