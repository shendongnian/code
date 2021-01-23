       public class SubmitedCityViewModel
       {
           public int StateId {get;set;}
         
           public List<CityViewModel> Cities {get;set;}
       }
    
       public class CityViewModel
       {
           public int cityId {get;set;}
           public bool Include {get;set;}    
       }
    
       
       
       public JsonResult SubmitCities(SubmitedCityViewModel model){
               foreach(var city in model.Cities)
               { 
                  if (city.Inclue)
                   {
                         //update db to include
                   }                  
                   else
                   { 
                       //update db to remove
                   }
               } 
       } 
