    public Subject<Thing> BufferedAdds {get; private set;}
    public Subject<Thing> BufferedChanges {get; private set;}
    public Subject<Thing> BufferedRemoves {get; private set;}
    _adds = Observable.FromEvent<EventDelegateAdd, Thing>(
        ev => new EventDelegateAdd(ev),
        h => mSource.AddingThing += h,
        h => mSource.AddingThing -= h);
    BufferedAdds = new Subject<Thing>();
    _changes = Observable.FromEvent<EventDelegateChange, Thing>(
        ev => new EventDelegateChange(ev),
        h => mSource.ChangingThing += h,
        h => mSource.ChangingThing -= h);
    BufferedChanges = new Subject<Thing>();
    _removes = Observable.FromEvent<EventDelegateRemove, Thing>(
        ev => new EventDelegateRemove(ev),
        h => mSource.RemovingThing += h,
        h => mSource.RemovingThing -= h);
    BufferedRemoves = new Subject<Thing>();
