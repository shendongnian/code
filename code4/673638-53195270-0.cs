    public class DbData 
    {
        List<Person> PersonList;
        List<Location> LocationList;
        public DbData()
        {
            using (var context = new MyContext())
            {
                 PersonList = context.Persons.ToList();
                 LocationList = context.Locations.ToList();
            }
        }
        public void UpdatePersonLocation(Person person, int newLocationId)
        {
            using (var context = new MyContext())
            {
                var location = LocationList.Where(l=>l.id==newLocationId).Single();
                //you need to update both the id and the location for this to not throw the exception
                person.CurrentLocationId == newLocationId;
                person.CurrentLocation == location;  
                context.Entry(person).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        //or if you're giving it the location object...
        public void UpdatePersonLocation(Person person, Location location)
        {
            using (var context = new MyContext())
            {
                //you need to update both the id and the location for this to not throw the exception
                person.CurrentLocationId == location.id;
                person.CurrentLocation == location;  
                context.Entry(person).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
