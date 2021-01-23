     int rowCount = 4; //number of rows 
     int spaceCount = 2; //number of spaces before **, change as desired
     int k; //number of times ** is printed each row, must remain always 1
       
     for(int i = 0; i < rowCount; i++){
           System.out.println();//starts each row with a new line
           for(int j = 1; j < spaceCount; j++){
               System.out.print(" ");//prints j spaces in begginning of each row
           }
           spaceCount++;//increment spacecount each row, so j can also go + 1 
           for(k = 1; k <= k - (k-1); k++){
               System.out.print("**");//each row prints ** k times
           }
           k--;//k must remain 1
     }
