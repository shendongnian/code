    class BaseClass
    {
        string Name {get; set;}
        int id {get; set;}
    }
    
    class BlueprintsManager
    {
        class WorkingStandardBlueprint : BaseClass
        {
        
        }
    }
    
    private void ShowBlueprints<T>(List<T> class_array) where T : BaseClass
    {
        for (T item in class_array)
        {       
            Console.WriteLine(item.Name);
        }
    }
