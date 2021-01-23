public void Swap(MyIndexedObject o, string indexer, object newValue, 
                    ref object oldValue)
{
    if(o.Contains(indexer))
    {
        oldValue = o[indexer];
    }
    else
        oldValue = null;
    o[indexer]=newValue;
}
public bool TryGetValue(MyIndexedObject o, string index, out object value)
{
    value=null;
    if(o.Contains(index))
    { 
        value = o[value];
        return true;
    }
    return false;
}
public void TrySwapValue(MyIndexedObject o, string indexer1, string indexer2)
{
    object valHolder1=null,valHolder2=null;
    if(TryGetValue(o,indexer1, out valHolder1))
    {
        Swap(o, indexer2, valHolder1,ref valHolder2);
        o[indexer1] = valHolder2;
    }
}
