    interface IBlueprint
    {
        int ID {get;set;}
        int Name {get;set;}
    }
    class MyClass 
    {
        private void ShowBlueprints<T>(IEnumerableT> values) where T : IBlueprint 
        {
            // access properties of IBlueprint
        }
        // I presume you 'know something' about your 'T'-s, have an interface -
        // ...if you don't you should if possible
    }
