    StringBuilder sb = new StringBuilder();
    DataTable dtOutput = Generix.getFeedData(1,ref Connection);
    foreach (DataRow drOutput in dtOutput.Rows)
    {
        sb.Append("IST: ");
        foreach (DataColumn dcOutput in dtOutput.Columns)
        {
            sb.Append(Convert.ToString(drOutput[dcOutput]) + "\t");
        }
        sb.AppendLine();
    }
