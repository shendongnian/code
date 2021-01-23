            using (testEntities Setupctx = new testEntities())
            {
                int ID = Int32.Parse(lblID.Text);
                var SHquery = (from sh in Setupctx.shifthours
                             where sh.idShiftHours == ID
                             select sh).First();
                    SHquery.shiftTiming_start = txtStart.Text;
                    SHquery.shiftTiming_stop = txtStop.Text;
                    Setupctx.SaveChanges();
                    txtStart.Text = "";
                    txtStop.Text = "";
                    this.Edit_Shift_Hours_Load(null, EventArgs.Empty);
                    MessageBox.Show("Shift Timing Has Been Updated.");
            }
        }
