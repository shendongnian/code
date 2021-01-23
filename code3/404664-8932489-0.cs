      int month =-1;
      if(int.TryParse(userInputString, out month)){
          if(month>=1 && month <=12) {
          
               DateTime dt = new DateTime(
                                   DateTime.Now.Year, 
                                   month, 
                                   DateTime.Now.Day);
          }
      }     
  
