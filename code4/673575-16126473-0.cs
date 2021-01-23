    private void ShowBlueprints<T>(List<T> class_array)
    {
        for (BlueprintsManager.WorkingStandardBlueprint item in class_array)
        {
            if(typeof T is BlueprintsManager.WorkingStandardBlueprint)
            {
                Console.WriteLine(((BlueprintsManager.WorkingStandardBlueprint)item).whateverpropertyyouhavedefined);
            }
        }
    }
