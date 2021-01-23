     if (!string.IsNullOrEmpty(Convert.ToString(txtBoxId.Text)))
            {
                string IdOrder = Convert.ToString(txtBoxId.Text.Trim());
                //replacing "enter" i.e. "\n" by ","
                string temp = IdOrder.Replace("\r\n", ",");            
                string[] ArrIdOrders = Regex.Split(temp, ",");
                for (int i = 0; i < ArrIdOrders.Length; i++)
                {
                  //your code
                }
             }
