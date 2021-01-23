    public class MyViewModel
    {
      //constructor and other stuff here
      public string Street{
        get { return this.Person.PrimaryAddress.StreetOne; }
        set {
           if ( this.Person.PrimaryAddress.StreetOne!= value ) {
             this.Person.PrimaryAddress.StreetOne = value;
             OnPropertyChanged( "Street" );
           }
       }
     }
