    public static TCollectionOut ConvertCollection<TCollectionIn, TCollectionOut, TIn, TOut>(TCollectionIn input)
            where TCollectionIn : IEnumerable<TIn>
            where TCollectionOut : ICollection<TOut>, new()
            where TOut : new()
        {
            var res = new TCollectionOut();
    
            foreach (dynamic item in input)
            {
                dynamic o = new TOut();
                ConvertItem(item, o);
                res.Add(o);
            }
            return res;
        }
    
        public static TCollectionOut ConvertCollectionMoreDynamic<TCollectionIn, TCollectionOut>(TCollectionIn input)
            where TCollectionIn : IEnumerable
    
        {
            dynamic res = Activator.CreateInstance(typeof (TCollectionOut));
    
            var oType = typeof (TCollectionOut).GetMethod("Add").GetParameters().Last().ParameterType;
    
            foreach (dynamic item in input)
            {
                dynamic o = Activator.CreateInstance(oType);
                ConvertItem(item, o);
                res.Add(o);
            }
            return res;
        }
    
        public static void ConvertItem(ClassA input, ClassB output)
        {
            output.Data = input.Data;
        }
