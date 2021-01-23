    static void TupleListSelectQuery<R>(IEnumerable<T> lst, int itemNumber)    where R : IStructuralEquatable, IStructuralComparable, IComparable
        {
            var items= lst.Select(t => typeof(T).GetProperty("Item" + Convert.ToString(itemNumber);).GetValue(t)).ToList();
        }
    
