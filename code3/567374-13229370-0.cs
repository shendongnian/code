    class MyClass
    {
        List<int> list;
        public MyClass()
        {
            list  = new List<int>();
        }
        private void Validate()
        {
            if (Convert.ToInt32(DobbelWaarde.Text) == 1)
            {
                if (list.Contains(1))
                {
                    Console.WriteLine("1 is allready been chosen");
                }
                else
                {
                    list.Add(1);
                    // ...
        }
    }
