        [WebMethod]
        public RadComboBoxData FindEmployee(RadComboBoxContext context)
        {
            RadComboBoxData comboData = new RadComboBoxData();
            using (DataBaseContext dbc = new DataBaseContext())
            {
                IQueryable<Employee> Employees = dbc.FindEmployee(context.Text);
                int itemOffset = context.NumberOfItems;
                int endOffset = Math.Min(itemOffset + 10, Employees.Count());
                List<RadComboBoxItemData> result = new List<RadComboBoxItemData>();
                var AddingEmployees = Employees.Skip(itemOffset).Take(endOffset - itemOffset);
                foreach (var Employee in AddingEmployees)
                {
                    RadComboBoxItemData itemData = new RadComboBoxItemData();
                    itemData.Text = Employee.Person.FullName;
                    itemData.Value = Employee.EmployeeID.ToString();
                    result.Add(itemData);
                }
                comboData.EndOfItems = endOffset == Employees.Count();
                comboData.Items = result.ToArray();
                if (Employees.Count() <= 0)
                    comboData.Message = "No matches";
                else
                    comboData.Message = String.Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", endOffset, Employees.Count());
                return comboData;
            }
        }
