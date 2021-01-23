    private void UpdateTabularDataTable(SqlConnection connection)
    {
          table.Columns.Add(Constants.RejectedUiColumnName, typeof(bool));
          table.Columns.Add(Constants.RejectedReasonUiColumnName, typeof(string));
          foreach (var row in table.Rows.Cast<DataRow>())
          {
            var contourId = (Guid)row.ItemArray[0];
            // this is a Dictionary of objects which are rejected.  The others are accepted.
            string rejectedReason;
            var isRejected = _rejectedParticleReasonHolder.TryGetValue(contourId.ToString(), out rejectedReason);
            row[Constants.RejectedUiColumnName] = isRejected;
            row[Constants.RejectedReasonUiColumnName] = rejectedReason;
          }
        }
      }
    }
