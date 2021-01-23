    class Loader
        {
            
            public void Execute(ItemsToLoad argObj)
            {
                if(argObj == null)
                    argObj = new ItemsToLoad();
    
                argObj.Add(19);
            }
    
            public class ItemsToLoad
            {
                public virtual void Add(int a)
                {
                    Console.WriteLine("Reached ItemsToLoad.");
                }
            }
        }
    class ChildLoader:Loader
        {
            public void Execute(ItemsToLoad argObjLoader)
            {
                if (argObjLoader == null)
                    argObjLoader = new ChildItemsToLoad();
    
                base.Execute(argObjLoader);
        }
        class ChildItemsToLoad : Loader.ItemsToLoad
        {
            public override void Add(int b)
            {
                Console.WriteLine("Reached ChildItemsToLoad.");
            }
        }
    }
