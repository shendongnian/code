    class Form1
    {
        int counter;
        DataTable table; //class variable so we can access to the reference from all over the class
        void ButtonForth_Click()
        {
           if(counter < table.Rows.Count)
              counter++;
           YourMethod();
        }
    
        void ButtonBack_Click()
        {
           if(counter > 0)
              counter--;
           YourMethod();
        }
    
        void YourMethod()
        {
            DataRow row = table.Rows[counter];
            if(row.Count > 0 )
            {
               SurnametextBox.Text = row["Surname"].ToString();
               FirstNametextBox.Text = row["Firstname"].ToString();
               PhonetextBox.Text = row["Phone"].ToString();
               ContactTypetextBox.Text = row["ContactType"].ToString();
            }
            //no need of try, catch block, is there are all the names correct (textobxes, and columns of datatable)
        }
    }
