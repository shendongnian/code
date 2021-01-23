    public class ValuesController : ApiController
    {
        [System.Web.Http.AcceptVerbs("POST")]
        public CustomListType POST(CustomListType myList)
        {
            CustomListType newList = new CustomListType();
            newList.myArray = new List<int>();
            foreach (var item in myList.myArray)
            {
                int newItem = Convert.ToInt32(myList.myArray[item]) + 1;
                newList.myArray.Add(newItem);
            }
            return newList;
        }
        public class CustomListType
        {
            public List<int> myArray { get; set; }
        }
    }
