    if (bookingRow.Table.Columns.Contains(kvp.Key))
            {
               String passedValue = kvp.Value;
               var columnValue = bookingRow[kvp.Key];
               Type columnType = bookingRow[kvp.Key].GetType();
               //var passedObject = Convert.ChangeType(passedValue, columnType);
               if (!passedValue.StringEquals(columnValue, columnType))
               {
                  String cColumnValue = columnValue.ToString().Trim();
                  if (cColumnValue != passedValue) // Double check to prevent cases of "" vs. "          "
                     this.SaveToBookingHistory(booking_id, "M", kvp.Key, cColumnValue, passedValue, ref messageText, ref statusCode);
               }
            }
