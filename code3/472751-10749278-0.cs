    public class City 
    {
       
       int counter = 0;
       public City()
       {
           //fill 10 elements by default
           Enumerable.Range(0, 10).ToList().ForEach(counter =>vm.Details.Add(new City.Detail());
       }
    .
    .
    }
    
    //Now define your add method as following
    public void AddDetails(Details d)
    {
       //remove the dummy element  
       vm.Details.RemoveAt(counter);
      //add original element and increase the counter, so next element would be added at next index
       vm.Details.insert(counter++, d);
    }
