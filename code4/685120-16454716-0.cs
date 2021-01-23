     protected void Page_Load(object sender, EventArgs e)
            {
    
                GetAnniversarydate();   
    
    
            }
    
     protected void GetAnniversarydate()
            { 
             DateTime _anniversarydate = new DateTime(2005, 6, 9);
                
                DateTime _currentdate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
    
                //Comparing the anniversary day and month with current day and month
                if ((_anniversarydate.Day == _currentdate.Day) && (_anniversarydate.Month == _currentdate.Month))
                {
                    int _Yeardifference = _currentdate.Year - _anniversarydate.Year;
    
                    Response.Write(string.Format("Today is your {0} anniversary",_Yeardifference));
                
                }
            }
