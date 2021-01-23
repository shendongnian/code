    public static List<MyClass> Assign (List<MyClass> assign, int i)
    {         
         for(int j=0;j<assign.Count;j++){
             assign[j].ID = i;
             i++
         }
    }
