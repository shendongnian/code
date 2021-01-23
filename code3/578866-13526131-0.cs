    var workOrderList = new List<WorkOrder>(
        from index in Enumerable.Range(1, orders.Length)
        let totalQuantity = random.Next(1, 5) * 8
        select new WorkOrder
        {
            OrderID = orders[index - 1],
            Status = status[random.Next(0,status.Length-1)],
            TotalQuantity = totalQuantity,
            ScheduleCollection = new ObservableCollection<Schedule>
            {
              new Schedule
                {
                    Color = colors[random.Next(0,colors.Length-1)],
                    Model = models[random.Next(0,models.Length-1)],
                    Status = status[random.Next(0,status.Length-1)],
                    TotalNumber = // Do something with totalQuantity
                }
            }
        });
