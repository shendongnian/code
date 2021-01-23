    public int FirstHeight
     {
       get
         {
          double Num;
          bool isNum = double.TryParse(firstheight1, out Num);
          if (isNum)
         {
           return firstheight1;
          }
        else
        {
         return 0; or 
         your message goes here 
        }
}
      }
