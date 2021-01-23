    var columns = JobListGrid.Columns.CloneFields(); //Will get all the columns bound dynamically to the gridview.
    var columnToMove = JobListGrid.Columns[0]; //My first column is Action Column
    JobListGrid.Columns.RemoveAt(0);           // Remove it
    JobListGrid.Columns.Insert(columns.Count - 1, columnToMove); // Moved to last
    JobListGrid.DataBind();                    // Bind the grid . 
