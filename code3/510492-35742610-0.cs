                for (int j = 0; j <= listView2.Items.Count - 1; j++)
                {
                    string test = listView2.SelectedItems[j].SubItems[1].Text;
                    string MyConnection2 = "datasource=localhost;port=3306;username=root;password=root";
                    string Query = "delete from TABLE_NAME where COL_NAME='" + test + "'";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();
                    MessageBox.Show("Data Deleted");
                   // txtCustomerName.Text = test;
                    //listView2.Items.Remove(listView2.Items[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
