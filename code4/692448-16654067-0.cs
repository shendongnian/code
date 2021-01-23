        public void DoSomething(Action<object> something)
        {
            if (something != null)
            {
                something(getObject());
            }
        }
