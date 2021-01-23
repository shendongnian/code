    public class myObjectController : ApiController
    {
        // ... code for GET/PUT/DELETE versions omitted ...
        // POST api/myObject
        public myObject PostmyObject(myObject myObject)
        {
            // code to save and update myObject
            return myObject;
        }
    }
