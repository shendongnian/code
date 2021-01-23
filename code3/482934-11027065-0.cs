interface IReadableHolder&lt;T&gt; { T Value {get;} }
class MutableHolder&lt;T&gt; : IReadableHolder&lt;T&gt;
{
  public T Value;
  IReadableHolder.Value {get {return Value;} }
  public MutableHolder(T newValue) { Value = newValue; }
  public MutableHolder(IReadableHolder&lt;T&gt; it) { Value = it.Value; }
}
class ImmutableHolder&lt;T&gt; : IReadableHolder&lt;T&gt;
{
  T _Value;
  public Value {get {return _Value;} }
  public ImmutableHolder(T newValue) { _Value = newValue; }
}
