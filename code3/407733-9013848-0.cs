// Delegate type definitions--should go somewhere
  delegate ActionByRef&lt;T1&gt;(ref T1 p1);
  delegate ActionByRef&lt;T1,T2&gt;(ref T1 p1, ref T2 p2);
  delegate ActionByRef&lt;T1,T2,T3&gt;(ref T1 p1, ref T2 p2, ref T3 p3);
// Code within the EnhancedList&lt;T&gt; type:
  T _items[];  // Array to hold actual items
  void ActOnItem(int index, ActionByRef&lt;T&gt proc)
    { proc(ref _items[index]); }
  void ActOnItem&lt;PT1&gt;(int index, ActionByRef&lt;T,PT1&gt proc, ref PT1 p1)
    { proc(ref _items[index], p1); }
  void ActOnItem&lt;PT1,PT2&gt;(int index, ActionByRef&lt;T,PT1,PT2&gt proc, 
                          ref PT1 p1, ref PT2 p2)
    { proc(ref _items[index], ref p1, ref p2); }
