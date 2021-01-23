     private void btn_search_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_search.Text))
                {
                    lbl_search_error.Text = "Please Enter name to search";
                }
                else
                {
    
                    StreamReader sr = new StreamReader(@"path.txt");
    
                    string line;
                    string searchkey = txt_search.Text;
                    sr.ReadToEnd();
    
    
                    string temp;
                    while ((line = sr.ReadLine()) != null)
                    {
                       if (line.Contains(searchkey))
                       {
                          temp = line;
                          break;
                       }
                    }
                    sr.Close();
    
                    string[] data = temp.Split(':');
                    txt_result_name.Text = data[0];
                    txt_result_phno.Text = data[1];
                }
            }
            catch (Exception ex)
            {
                lbl_search_error.Text = ex.Message;
            }
        }
    
   
     
