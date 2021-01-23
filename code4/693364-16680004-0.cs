        if (notesDataSet.HasChanges())
        {
            DataSet editDataSet = notesDataSet.GetChanges();
            notesClient.UpdatePatientNotes(editDataSet);
        }
        notesDataSet.AcceptChanges();
