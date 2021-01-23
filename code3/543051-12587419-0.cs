    List<string[]> list = ...
    for(int i = 0; i < list.Count; i++)
    {
        // copy to a local variable (list[i] is a property, which can't be passed 'ref')
        string[] array = list[i];
    
        // resize the local variable. (this creates a new string[] object)
        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = "EndOfBlock";
    
        // put the new object back in the list, replacing the old smaller one.
        list[i] = array;
    }
