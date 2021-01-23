    public class PermutationFinder<T>
    {
        private T[] items;
        private Predicate<T[]> SuccessFunc;
        private bool success = false;
        public void Evaluate(T[] items, Predicate<T[]> SuccessFunc)
        {
            this.items = items;
            this.SuccessFunc = SuccessFunc;
            Recurse(0);
        }
        private void Recurse(int index)
        {
            if (index == items.Count())
                success = SuccessFunc(items);
            else
            {
                for (int i = index; i < items.Count(); i++)
                {
                    T tmp = items[index];
                    items[index] = items[i];
                    items[i] = tmp;
        
                    Recurse(index + 1);
                    if (success)
                        break;
                    
                    tmp = items[index];
                    items[index] = items[i];
                    items[i] = tmp;
                }
            }
        }
    }
