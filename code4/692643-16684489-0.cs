        class Employee
        {
            public string Name { get; set; }
            public int Gender { get; set; }
        }
        class GenderLookup
        {
            public string Display { get; set; }
            public int Value { get; set; }
        }
        private void SetupGrid()
        {
        GenderLookup[] _lookups = new[]
            {
                new GenderLookup { Value = 0, Display = "unknown" }, 
                new GenderLookup { Value = 1, Display = "Male" },
                new GenderLookup { Value = 2, Display = "Female" }, 
                new GenderLookup { Value = 3, Display = "Other" }
            };
        Employee[] _employees = new[]
            {
                new Employee() { Gender = 1, Name = "James T. Kirk" }, 
                new Employee() { Gender = 2, Name = "Lt. Uhura" },
                new Employee() { Gender = 3, Name = "Data" }
            };
            GridView.AutoGenerateColumns = false;
            GridView.DataSource = _employees;
            GridView.Columns.Add(
                new DataGridViewTextBoxColumn() 
                    { 
                        DataPropertyName = "Name" 
                    }
                );
            GridView.Columns.Add(
                new DataGridViewComboBoxColumn()
                    {
                        DataSource = _lookups,
                        DisplayMember = "Display",
                        ValueMember = "Value",
                        DataPropertyName = "Gender"
                    }
                );
        }
