    for (int i = 0; i < dgvInput.Rows.Count; i++)
        {
            DataGridViewRow row = dgvInput.Rows[i];
            int machineTypeId = Convert.ToInt32(row.Cells[1].Value);
            Update update = new Update();
            update.MachineType.Add(Check.prombase.MachineTypes.First(mt => mt.MachineTypeId == machineTypeId));
            
            var programVal = row.Cells[5].Value.ToString() + "v";
            var program = database.Programs.FirstOrDefault(program => program.ProgramVersion.StartsWith(programVal));
            if (program == null)
                program = database.Programs.First(program => program.MachineType.MachineTypeId == machineTypeId);
            update.Program.Add(program);            
            database.AddToUpdates(update);
            database.SaveChanges();
            if (update.MachineType.Count == 0 || update.Program.Count == 0)
                MessageBox.Show("Error!");
        }
