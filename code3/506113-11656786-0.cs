    namespace AESSmart.ViewModels
    {
      public class HomeIndexViewModel
      {
        public power_weatherstationhistory WeatherStationHistory {get;set;}
        public DateTime startingDate {get;set;}
        public DateTime endingDate {get;set;}
        public DateTime utcStartingDate {get;set;}
        public DateTime utcEndingDate {get;set;}
        public double LifeTimeGeneration {get;set;}
        public double CO2Offset {get;set;}
        public double GallonsOfGasolineOffset {get;set;}
        public double BarrelsOfOilOffset {get;set;}
        public string Message {get;set;}
        
        public void setUTCDatesTimes()
        {
          //Contains code to convert dates to the UTC equivalent 
        }
        
        public void setOffsetsAndPowerGenerated()
        {
          /*
           * CONTAINS A BUNCH OF CODE TO GATHER THE GENERATED POWER READINGS
           * FOR THE SPECIFIED DATETIME AND STORES RESULT IN LifeTimeGeneration.  
           * ALSO, PERFORMS CALCULATIONS TO GET AND STORE VALUES FOR CO2Offset, 
           * GallonsOfGasolineOffset, AND BarrelsOfOilOffset
           */
        }
        
        public void saveWeather()
        {
          AESSmartEntities db = new AESSmartEntities();
          db.PowerWeatherStationHistorys.Add(WeatherStationHistory);
          db.SaveChanges();
        }
        
        public void setWeather()
        {
          AESSmartEntities db = new AESSmartEntities();
          DateTime tempDate = (DateTime.UtcNow).AddMinutes(-5);
        
          var myQuery = (from s in db.PowerWeatherStationHistorys
                         where s.recordTime >= tempDate
                         orderby s.recordTime descending
                         select s).Take(1);
        
          if(myQuery.Count() > 0) 
          {
            /*
             * IF A WEATHER RECORD EXISTS IN THE THE DATABASE NO OLDER 
        	 * THAN 5 MINUTES THEN USE THAT INFORMATION
             */
          }
          else
          {
        	/*
             * IF A RECORD DOES NOT EXIST IN THE THE DATABASE NO OLDER 
        	 * THAN 5 MINUTES THEN GET WEATHER INFORMATION FROM WUNDERGRAOUND API 
        	 * THEN SAVE IN DATABASE
             */
            
            saveWeather();
          }
        }
      }
    }
