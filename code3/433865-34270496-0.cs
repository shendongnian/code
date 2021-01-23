bool condition = listener.ReceiveWeakEvent(managerType, sender, args);
if (!condition)
{
    Invariant.Assert(condition, SR.Get("ListenerDidNotHandleEvent"), SR.Get("ListenerDidNotHandleEventDetail", new object[] { listener.GetType(), managerType }));
}
