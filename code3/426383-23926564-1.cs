    // To count checklist item
      int a = ChkMonth.Items.Count;
            int count = 0;
            for (var i = 0; i < a; i++)
            {
                if (ChkMonth.Items[i].Selected == true)
                {
                    count++;
                }
            }
