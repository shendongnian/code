    public myRows(string str)
           {
              string[] splitArray = str.Split(); //split on white space
              if(splitArray.Length > 7)
                  {
                   Number1 = Convert.ToDecimal(splitArray[0]);
                   //,....... So on
                  }
           }
