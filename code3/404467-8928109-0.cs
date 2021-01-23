    public class BadStringMe : StringMe
    {
        public void FurtleWithList()
        {
            while (true)
            {
                _stringArrayList.Add("Eek!");
                _stringArrayList.Clear();
            }
        }
    }
