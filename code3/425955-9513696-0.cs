            List<string> listName = new List<string>();
            using (StreamReader reader = new StreamReader("C:\\file1.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    listName.Add(line); // Adding name in list
                }
            }
            List<string> listRowsStr = new List<string>();
            List<string> listRowContainName = new List<string>();
            
            //Adding all rows of particular column in list
            listRowsStr=(from name in dt.AsEnumerable()
                       select name.Field<string>("column_name")).ToList<string>();
            foreach (string name in listName)
            {
                foreach (string rowStr in listRowsStr)
                {
                    if (rowStr.Contains(name))
                    {
                        listRowContainName.Add(rowStr);//Adding the name containing string into the sepearte list i.e.listRowsStr
                    }
                }
            }
