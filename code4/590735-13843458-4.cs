    public class Model
    {
        public event Action<string> DataAdded; // subscribe to this event in form1
    
        public void AddData(string data) // call this method in form2
        {
            if (DataAdded != null)
                DataAdded(data);
        }
    }
