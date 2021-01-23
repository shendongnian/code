        DataTable getTxnOutput = // Get DataTable by Calling Stored Procedure;
        Table txnOutputs = Generix.convertDataTable2HTMLTable(getTxnOutput);
        int i = 0;
        foreach (TableRow trOutput in txnOutputs.Rows)
        {
            if (trOutput.TableSection == TableRowSection.TableBody)
            {
            /*  Here i am doing some operation using column which i want to delete afterwards           */      
             txnOutputs.Rows[i].Cells.Remove(trOutput.Cells[6]); //Now delete that column
            }
            i++;
        }
        Page.Controls.Add(txnOutputs);
