         int i = 0;
         foreach (DataRow dr in dt.Rows)
           {
               if (i == 0)
               {
                   comboBox1.SelectedText = dr[0].ToString();
               }
               else
               {
                   comboBox1.Items.Add(dr[0].ToString());
               }
               i++;
             
           }
