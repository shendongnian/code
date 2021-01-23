    LoadOperation<ATDueDate> Load1 = context1.Load<ATDueDate>(context1.GetATDueDatesByEntityQuery("I"));
            Load1.Completed += (s, ea) =>
            {
                this.DataContext = Load1.Entities;
                comboBox2.ItemsSource = Load1.Entities.Select(a => a.PackageName.Substring(1,2)).Distinct();
            };
