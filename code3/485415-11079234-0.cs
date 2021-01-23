    public class HDate
        {
            private string StartYear;
    
            public string StartYear1 {get ; set } 
            //you can write that when you use framwork 3.0 or hit
    
      //public HDate() { }// you can note have 2 constructor with same signature !! 
    
            public DateTime today;
            public HDate(){
            today = DateTime.Now;
          //Some Code here
          }
         
    // you can make methode :
    public updateDate()
    {
    DateTime StartDate, EndDate;
    // some code here
    return StartDate+" ; "+EndDate ; // string is between " " ! not between ' ' ;)
    }
    }// end of class.. after you can declarate hd and make hd.updateDate(); good luck
