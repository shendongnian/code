    public class Person
    {
        protected virtual void ValidateLastName() { }
    
        public string LastName
        {
           get { return lastName; }
           set 
           {
                 ValidateLastName();
                 lastName = value;
           }
        }
    }
    
    public class Employee : Person
    {
        protected override void ValidateLastName()
        {
            // your validation logic here
        }
    }
