            try
            {
                if (Program.YesNoQuestion(string.Format("Cancel print job for the selected document?", printQueueGridView.SelectedRows.Count)) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                PrintQueueItem item = printQueueBinding.Current as PrintQueueItem;
                if (item == null)
                {
                    throw new ArgumentNullException("Could not obtain an instance of 'PrintQueueItem'");
                }
                item.PrintStatus = "Cancelled";
                this.db.Database.ExecuteSqlCommand("exec usp_PrintQueue_Update {0}, {1}", item.PrintQueueID,
                                                                                               item.PrintStatus);
                //this.db.PrintQueue.Load();
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (DbEntityEntry entry in ex.Entries)
                {
                    entry.Reload();
                }
            }
