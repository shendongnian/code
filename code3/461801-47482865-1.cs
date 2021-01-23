     SqlDataReader reader = myComm.ExecuteReader();
            if (reader.HasRows)
            {               
                string colorName ="";
                while (reader.Read())                   
                {
                    switch ((string)reader.GetValue(1))
                    {
                        case "Total Employee(s)":
                            colorName = "Blue";
                            break;
                        case "Present":                       
                            colorName = "Green";
                            break;
                        case "Late":
                        case"Absent":
                        case "During Less":
                        case "Early Going":
                            colorName = "Red";
                            break;
                        case "Leave":
                            colorName = "Orange";
                            break;
                        default:
                            colorName = "Gray";
                            break;
                    }
                    dataItems.Add(new Tuple<string, Object>(colorName, reader.GetValue(2)));
        }
 
