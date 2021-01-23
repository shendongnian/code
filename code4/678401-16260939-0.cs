            DataRow row;
            DateTime curRowDt, nextRowDt;
            object curObj, nextObj; // Used only for conversions
            for (int i = 0; i < precip.Rows.Count - 1; ++i)
            {
                // Resetting id numbers
                precip.Rows[i][2] = i;
                // Throws exception when changed to
                // curRowDt = (DateTime)precip.Rows[i][0];
                curObj = precip.Rows[i][0];
                nextObj = precip.Rows[i + 1][0];
                curRowDt = Convert.ToDateTime(curObj);
                nextRowDt = Convert.ToDateTime(nextObj);
                if (curRowDt.AddHours(1.0) != nextRowDt)
                {
                    for (int j = 1; j < nextRowDt.Subtract(curRowDt).Hours; ++j)
                    {
                        ++i;
                        row = precip.NewRow();
                        row.ItemArray = new object[] { curRowDt.AddHours(j), null, i };
                        precip.Rows.InsertAt(row, i);
                    }
                }
            }
            // Resetting last row's id number
            precip.Rows[precip.Rows.Count - 1][2] = precip.Rows.Count - 1;
