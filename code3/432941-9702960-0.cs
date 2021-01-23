    IEnumerable<T> getItems()
    {
        if ( someCondition.Which.Yields.One.Item )
        {
            yield return MyRC;
        }
        else
        {
            foreach(var i in myList)
                yield return i;
        }
    }
