struct ControllableEnumeratorItem&lt;T&gt;
{
  private ControllableEnumerator parent;
  public T Value {get {return parent.Value;}}
  public bool MoveNext() {return parent.MoveNext();}
  public ControllableEnumeratorItem(ControllableEnumerator newParent)
    {parent = newParent;}
}
