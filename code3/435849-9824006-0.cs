            private void updateClassInstance()
        {
            DataRow row = dClassInstance.Rows[chosenClassInstance - 1];
            for (int i = 4; i <= 42; i++)
            {
                if (i <= 23) row[i] = Convert.ToInt32(spellInfoBoxes[i - 4].Text);
                if (i >= 34) row[i] = Convert.ToInt32(spellInfoBoxes[i - 14].Text);
            }
            try
            {
                dClassInstance.Rows[chosenClassInstance - 1].AcceptChanges();
                dClassInstance.Rows[chosenClassInstance - 1].SetModified();
            }
            catch { }
            classDataAdapter.UpdateCommand = createCharInstanceCommand();
            classDataAdapter.UpdateCommand.Connection = classConnection;
            int spellinfotest = this.classDataAdapter.Update(dClassInstance);
            this.classConnection.Close();
        }
