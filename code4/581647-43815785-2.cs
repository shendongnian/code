            string Query = "insert into DBname.TableName(id,Name,First_Name,Age,Address) values('" +this.IdTextBox.Text+ "','" +this.NameTextBox.Text+ "','" +this.FirstnameTextBox.Text+ "','" +this.AgeTextBox.Text+ "','" +this.AddressTextBox.Text+ "');";  
            
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);  
              
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);  
            MySqlDataReader MyReader2;  
            MyConn2.Open();  
            MyReader2 = MyCommand2.ExecuteReader();     
            MessageBox.Show("Save Data");  
            while (MyReader2.Read())  
            {                     
            }  
            MyConn2.Close();  
        }  
        catch (Exception ex)  
        {   
            MessageBox.Show(ex.Message);  
      }  
}
