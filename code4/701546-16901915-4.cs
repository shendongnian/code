    this.Controls.Add(
        new UserControl2(
            new EmployeeViewModel
            {
                LastName = (string)DR1["LastName"],
                Location = new Point(50, 30 * i),
                Tag = i
            }));
