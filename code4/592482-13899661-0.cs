    public List<Type1> param1 = new List<Type1>(); 
    public List<Type2> param2 = new List<Type2>();      
    List<Type3> var1 = MergeFoundSigns<Type1, Type3>(param1);
    List<Type4> var2 = MergeFoundSigns<Type2, Type4>(param2); 
    public List<TOut> MergeFoundSigns<TIn, TOut>(List<TIn> param)
    {
        // some logic
    }
