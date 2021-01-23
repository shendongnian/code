    public class Agency
    {
        public virtual void SubmitRental()
        {
            //can leave empty, or provide default behavior
        }
        // methods and properties/fields common to all Agencies.  
    }
    public class Agency1 : Agency
    {
        public override void SubmitRental()
        {
            //insert submit logic here
        }
        //methods and properties/fields specific to Agency1
    }
