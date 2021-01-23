          ServiceApUtils _apUtils = new ServiceApUtils();
               var   results = _apUtils.ADP_Processor(l_taxcode.ToArray(), l_amount.ToArray(),  l_row.ToArray());
                    //Response.Write(results[0].)
                 if (results[0].service_error!="")
                 {
                     Response.Write(results[0].service_error);
                 }//if the procedure has service errors
                 else if (results.Count > 0)//
                 {
                     foreach (var value in results){
                         TableRow tr = new TableRow();
                         Table1.Rows.Add(tr);
                           for (int i = 0; i < value.Length; i++{
                             //might have to update this logic as well:
                             TableCell tc = new TableCell();
                             tc.Text = value.FWWDIR_ROW + value.FWWDIR_ERR_INVOICE + value.FWWDIR_ERR_ACCOUNT;
                             tr.Cells.Add(tc);// = new TableCell();
                           }
          }
