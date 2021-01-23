     Object[] jobs = CLB_JobNo.Items.Cast<Object>().ToArray();
     foreach (Object obj in jobs)
     {
         SelectedJob = obj.ToString();
         if (JNos.Contains(SelectedJob))
         {
             CLB_JobNo.SetItemChecked(CLB_RowNo, true);
         }
         CLB_RowNo++;
     }
