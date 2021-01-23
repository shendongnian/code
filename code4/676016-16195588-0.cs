            DataTable dt = new DataTable();
            // (...) getting data, displaying on DataGridView - all works fine
            int columns = dt.Columns.Count; // getting column count
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn c in dt.Columns)
                {
                    // all old values are positive for debugging
                    double oldVal = Convert.ToDouble(row[c]);
                    // new values should become negative
                    double newVal = oldVal * -1;
                    row[c] = newVal; // im trying to update value like this
                    // THIS SHOWS POSITIVE NUMBERS (NOT UPDATED)
                    this.Text = row[c].ToString(); // this is simple debug
                }
            }
            dt.AcceptChanges();
