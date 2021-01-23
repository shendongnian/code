    _adds = Observable.FromEvent<EventDelegateAdd, Thing>(
        ev => new EventDelegateAdd(ev),
        h => mSource.AddingThing += h,
        h => mSource.AddingThing -= h);
    _changes = Observable.FromEvent<EventDelegateChange, Thing>(
        ev => new EventDelegateChange(ev),
        h => mSource.ChangingThing += h,
        h => mSource.ChangingThing -= h);
    _removes = Observable.FromEvent<EventDelegateRemove, Thing>(
        ev => new EventDelegateRemove(ev),
        h => mSource.RemovingThing += h,
        h => mSource.RemovingThing -= h);
