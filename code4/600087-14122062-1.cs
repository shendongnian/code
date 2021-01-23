    if (newNumber != 0)
         {
             string a = newNumber.ToString();
             for(int i = 1; i < a.Length; i++)
             {
                 int input1 = Convert.ToInt32(a[i-1]);
                 int input2 = Convert.ToInt32(a[i]);
                 if (input1 >= input2) //Note the reversed condition
                 {
                     return false; //Gives the false result
                 }
             }
             return true; //Computation finished, so the number is increasing
         }
    }
