delegate void ActionByRef&lt;T1>(ref T1 p1);
delegate void ActionByRef&lt;T1,T2>(ref T1 p1, ref T2 p2);
delegate void ActionByRef&lt;T1,T2,T3>(ref T1 p1, ref T2 p2, ref T3 p3);
interface IThing<T>
{ // Must allow client code to work directly with a field of type T.
  void ActOnThing(ActionByRef&lt;T> proc);
  void ActOnThing&lt;ExtraT1>(ActionByRef&lt;T, ExtraT1> proc, ref ExtraT1 ExtraP1);
  void ActOnThing&lt;ExtraT1, ExtraT2>
       (ActionByRef&lt;T> proc, ref ExtraT1 ExtraP1, ref ExtraT2 ExtraP2);
}
