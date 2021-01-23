            var dayList = new List<DateTime>() { 
                DateTime.Today, 
                DateTime.Today.AddDays(-1), 
                DateTime.Today.AddDays(-2) 
            };
            GridView2.DataSource = dayList;
            GridView2.DataBind();
