  // Define these delegates somewhere outside the struct
  delegate void ActionByRef2&lt;T&gt;(ref 1 param);
  delegate void ActionByRef2&lt;T1,T2&gt;(ref T1 p1, ref T2 p2);
  // Within StructArray&lt;T&gt;, define methods
  static void UpdateItemAtIndex(ref StructArray1&lt;T&gt; arr, int index, ActionByRef&lt;T&gt; proc);
  static void UpdateItemAtIndex&lt;TParam&gt;(ref StructArray1&lt;T&gt; arr, int index,
     ActionByRef&lt;T,TParam&gt; proc, ref TParam param);
