    var viewModel = employees.OrderBy(e => e.Name)
                               .ToArray()
                               .Select(e => new EmployeeViewModel
                                {
                                    EmployeeId = e.EmployeeID,
                                    Name = e.Name,
                                    Email = Membership.GetUser(e.UserID).Email,
                                    Active = e.Active
                                });
