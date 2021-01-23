interface ICountable { int Count {get;} }
interface IClearable { int Count {get;} }
interface IAppendable&lt;in T&gt; { void Add(T item); }
interface ICountableEnumerable&lt;out T&gt; : IConvertableToEnumerable, ICountable 
  {IEnumerable&lt;T&gt CopyAsEnumerable();}
interface IFetchable&lt;out T&gt; { T FetchAndRemove(ref bool wasNonEmpty); }
interface ISet&lt;T&gt; ICountable, IClearable, IAppendable&lt;T&gt;, IFetchable&lt;T&gt;,
          IConvertableToEnumerable&lt;T&gt;; 
