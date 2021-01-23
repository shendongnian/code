        {
            DataAccessLayer dal = new DataAccessLayer();
            int id = 23;
            string name = "mayank";
            string sname = "agarwal";
            int marks = 34;
            int a = dal.insert(id, name, sname, marks);
            LblUserName.Text = a.ToString();
            
           
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message.ToString());
                throw;
        }
