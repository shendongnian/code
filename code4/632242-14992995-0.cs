    using System.Threading.Tasks;    
    ....
    public void SomeMethod()
    {
        Task.Factory.StartNew(()=>
        {
            foreach (SomeModel x in TheListOfSomeModel)
            {
                //do some work
                ....
                if (SomeCondition)
                {
                     x.ExecuteQuery();
                }
             }
         });
    }
