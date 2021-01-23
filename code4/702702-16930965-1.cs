     if (e.CommandName == "delete")
         {
            int ActID, TskID;
            Int32.TryParse(gvQuestion.Rows[0].Cells[2].Text, out ActID);
            Int32.TryParse(gvQuestion.Rows[0].Cells[3].Text, out TskID);
            // Try to Debug here to show the value of ActID and TskID if you have the right values.
            if (ActID>0 && TskID > 0)
            {
            Model.question del = new Model.question(); // Entitiy CRUD
            del.ActivityID = ActID; // Value of ActivityID column in GV
            del.TaskID = TskID; // Value of TaskID column in GV
            daoQuestion.Delete(del);
            }
        }
