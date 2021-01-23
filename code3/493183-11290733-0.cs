    MyDatatBaseDataContext MyDB = new MyDatatBaseDataContext();
            var _Udate_2 = MyDB.Employees.Where(u => (u.Address == "WestSreet"));
            foreach (var item in _Udate_2)
            {
                item.Address = "WS";
            }
    MyDB.SubmitChanges(); // Need to call that
