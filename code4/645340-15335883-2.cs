    for (int i = 0; i < dgvInput.Rows.Count; i++)
        {
            DataGridViewRow row = dgvInput.Rows[i];
            int machineTypeId = Convert.ToInt32(row.Cells[1].Value);
            Update update = new Update();
            update.MachineType.Add(Check.prombase.MachineTypes.First(mt => mt.MachineTypeId == machineTypeId));
            
            var programVal = row.Cells[5].Value.ToString() + "v";
            var program = database.Programs.FirstOrDefault(prog => prog.ProgramVersion.StartsWith(programVal));
            if (program == null)
                program = database.Programs.First(prog => prog.MachineType.MachineTypeId == machineTypeId);
            update.Program.Add(program);            
            database.AddToUpdates(update);
            database.SaveChanges();
            //This will never show an error as the update that you are accessing here is the one you created in memory (Not the one in the DB)
            if (update.MachineType.Count == 0 || update.Program.Count == 0)
                MessageBox.Show("This will never show!");
            //To get the error, pull the update from the database again
            var updateNew = database.Updates.First(upd => upd.UpdateId == update.UpdateId);
            if (updateNew.MachineType.Count == 0 || updateNew.Program.Count == 0)
                MessageBox.Show("This will show if prog was not saved");
        }
