    public class MyViewModel
    {
        public IEnumerable<SelectListItem> Selections
        {
            get
            {
                return selections;
            }
            set
            {
                selections= value;
                // serialize SelectListItems to a json string
                SerializedSelections = Newtonsoft.Json.JsonConvert.SerializeObject(value);
            }
        }
        IEnumerable<SelectListItem> selections;
        public string SerializedSelections
        {
            get
            {
                return serializedSelections;
            }
            set
            {
                serializedSelections = value;
                if(Selections == null)
                {
                    // SelectListItems aren't defined.  Deserialize the string to the list
                    Selections = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<SelectListItem>>(value);
                }
            }
        }
        string serializedSelections;
    }
