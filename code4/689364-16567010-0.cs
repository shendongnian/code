    public class MyViewModel
    {
        public IEnumerable<int> Numbers
        {
            get
            {
                while (true)
                {
                    yield return 0;
                }
            }
        }
    }
