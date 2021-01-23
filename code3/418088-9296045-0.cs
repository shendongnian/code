     public class Window1: Window
     {
         private void Anymethod()
         {
            //just some code pieces
            string sqlStr2 = "SELECT Conference_Name, Year FROM MyTable";
            SqlDataAdapter dAdapt2 = new SqlDataAdapter(sqlStr2, cnStr);
            DataSet dataSet2 = new DataSet();
            dAdapt2.Fill(dataSet2);
            this.dtg1.ItemsSource = dataSet2.Tables["MyTable"].DefaultView;
         }
     }
