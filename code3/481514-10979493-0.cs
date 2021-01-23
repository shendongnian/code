    public class DataTableExample 
    {     
        public static void Main()     
        {         
            //adding up a new datatable         
            DataTable dtEmployee = new DataTable("Employee");            
            //adding up 3 columns to datatable         
            dtEmployee.Columns.Add("ID", typeof(int));         
            dtEmployee.Columns.Add("Name", typeof(string));         
            dtEmployee.Columns.Add("Salary", typeof(double));           
            //adding up rows to the datatable         
            dtEmployee.Rows.Add(52, "Human1", 21000);         
            dtEmployee.Rows.Add(63, "Human2", 22000);         
            dtEmployee.Rows.Add(72, "Human3", 23000);         
            dtEmployee.Rows.Add(110,"Human4", 24000);           
            // sorting the datatable basedon salary in descending order        
            DataRow[] rows= dtEmployee.Select(string.Empty,"Salary desc");           
            //foreach datatable         
            foreach (DataRow row in rows)         
            { 
                Console.WriteLine(row["ID"].ToString() + ":" + row["Name"].ToString() + ":" + row["Salary"].ToString());         
            }           
            Console.ReadLine();     
        }   
    }
