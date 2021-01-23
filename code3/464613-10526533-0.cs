public void Instantiate&lt;T&gt;()
{
    var myObject = Activator.CreateInstance&lt;T&gt;();
    // Do something with myObject
}
public void Instantiate(Type t)
{
    var myObject = Activator.CreateInstance(t);
    // Do something with myObject
}
public void Instantiate(string typeName)
{
    var detailType = Type.GetType(typeName);
    if (detailType == null)
    {
        throw new InvalidOperationException("Nice try, but type {0} doesn't compute :)");
    }
    var myObject = Activator.CreateInstance(detailType);
    // Do something with myObject
}
