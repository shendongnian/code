// User code will supply an implementation of one of these interfaces to the dispatching
// object, which will call its "Act" method with a proper type
interface IActUponGenericA
{
  void Act&lt;T&gt;(A&lt;T&gt; param);
}
interface IActUponGenericA&lt;PT1&gt;
{
  void Act&lt;T&gt;(A&lt;T&gt; param, PT1 extraParam1);
}
interface IActUponGenericA&lt;PT1,PT2&gt;
{
  void Act&lt;T&gt;(A&lt;T&gt; param, PT1 extraParam1, PT2 extraParam2);
}
// The dispatching object itself will implement this interface:
interface IWrapActUponGenericA&lt;T&gt;
{
  void CallAction(IActUponGenericA act, T param);
  void CallAction&lt;PT1&gt;(IActUponGenericA&lt;PT1&gt; act, T param, PT1 extraParam1);
  void CallAction&lt;PT1,PT2&gt;(IActUponGenericA&lt;PT1,PT2&gt; act, T param, 
                             PT1 extraParam1, PT2 extraParam2);
}
