static ExecAction&lt;T&gt;(T param, ref Action&lt;T&gt; proc)
{
  proc(param);
}
int TryParse(string st, Action&lt;ParseStatus&gt; failureAction)
{
  TryParse(st, ExecAction, ref failureAction);
}
