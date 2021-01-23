    var signal1 = new AsyncSubject<Unit>();
    var signal2 = new AsyncSubject<Unit>();
    var source1 = a.Do(item => { signal1.onNext(Unit.Default); signal1.onCompleted(); });
    var source2 = b.Do(item => { signal2.onNext(Unit.Default); signal2.onCompleted(); })).TakeUntil(signal1);
    var source3 = c.TakeUntil(signal2.Merge(signal1));
 
    return Observable.Concat(source1, source2, source3);
