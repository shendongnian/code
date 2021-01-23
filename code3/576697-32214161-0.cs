    public class Foo
    {
        //members here...
        public override bool Equals(object obj)
        {
            //implementation here
        }
        //You should probably also override GetHashCode to be thorough,
        //but that's an implementation detail...
    }
    
    //This method could stand on its own or you could change it to make it 
    //part of the implementation of one of the comparison interfaces...
    bool DictionariesEqual(Dictionary<string, Foo> x, Dictionary<string, Foo> y)
    {
        //If we're comparing the same object, it's obviously equal to itself.
        if(x == y)
        {
            return true;
        }
        //Make sure that we don't have null objects because those are
        //definitely not equal.
        if (x == null || y == null)
        {
            return false;
        }
        
        //Stop processing if at any point the dictionaries aren't equal.
        bool result = false;
        //Make sure that the dictionaries have the same count.
        result = x.Count == y.Count;
        
        //If we passed that check, keep going.
        if(result)
        {
            foreach(KeyValuePair<string, Foo> xKvp in x)
            {
                //If we don't have a key from one in the other, even though
                //the counts are the same, the dictionaries aren't equal so
                //we can fail out.
                Foo yValue;
                if(!y.TryGetValue(xKvp.Key, out yValue))
                {
                    result = false;
                    break;
                }
                else
                {
                    //Use the override of the Equals method for your object
                    //to see if the value from y is equal to the value from
                    //x.
                    result = xKvp.Value.Equals(yValue);
                    if(!result)
                    {
                        //If they're not equal we can just quit out.
                        break;
                    }
                }
            }
        }
        return result;
    }
