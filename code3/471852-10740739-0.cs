public delegate TResult TFuncByRef&lt;TParam,TResult&gt;(ref TParam);
public static TValue GetValueOrDefault&lt;TKey, TValue, TParam&gt;
  (this IDictionary source, TKey key, 
   FuncByRef&lt;TParam, TValue&gt; defaultSelector, 
   ref TParam param)
{
    ref TValue Result = default(TValue);
    if (!source.TryGetValue(key, ref Result))
        Result = defaultSelector(ref param);
    return Result;
}
struct CreatePersonParams {public string Name; public int Age; public bool IsMale};
static Person CreatePersonByName(ref CreatePersonParams param)
{
  return new Person(param.Name, param.Age, param.IsMale);
}
... then to use it...
{
  ...
  CreatePersonParams newPersonParams;
  newPersonParams.Name = "Emily";
  newPersonParams.Age = 23;
  newPersonParams.IsMale = False;
  ...
  whatever = myDict.GetValueOrDefault(keyValue, CreatePersonByName, ref newPersonParams);
  ...
}
