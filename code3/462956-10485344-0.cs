    interface IDalFacade
    {
        int DoAThing();
        bool DoAnotherThing();
    }
    class DalFacade : IDalFacade
    {
        public int DoAThing()
        {
            return 0;
        }
        public bool DoAnotherThing()
        {
            return false;
        }
    }
