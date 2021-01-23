    for (int j = 0; j < tblCols; j++)
    {
       TableCell tc = new TableCell();
       tc.Controls.Add(new LiteralControl("Job ID:" + jobId + "<br>" + "Job Designation:" + JobDesignation + "<br>" + "Job Description:" + JobDescription + "<br>" + "Vacancies:" + NoOfVacancies + "<br>" + "Ad Posted On:" + DatePosted + ""));
       tr.Cells.Add(tc);
    }
