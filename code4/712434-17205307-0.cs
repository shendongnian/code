    //Defines an interface that provides a function to get multiple dates from an object.
    public interface IGetDates
    {
         //You could use a Read-Only property too
         string[] GetDates();
    }
    public class Stuff : IGetDate
    {
         //other stuff...
         public string[] GetDates()
         {
              return new[]{ Date1, Date2, Date2, ect...};
         }
    }
