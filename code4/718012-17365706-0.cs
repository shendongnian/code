            var val1 = new Result();
            var val2 = new Result();
            foreach (var item in data) {
                if (item.Date == selectedDate) {
                    val1.Date += item.Val1;
                    val2.Date += item.Val2;
                }
                if (item.Date.Month == selectedMonth) {
                    val1.Month += item.Val1;
                    val2.Month += item.Val2;
                }
                if (item.Date.Year == selectedYear) {
                    val1.Year += item.Val1;
                    val2.Year += item.Val2;
                }
            }
