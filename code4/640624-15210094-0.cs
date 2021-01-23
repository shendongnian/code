    var signal = new AsyncSubject();
    var source1 = a.Do(item => { signal.onNext(); signal.onCompleted(); });
    var source2 = Observable.Amb(signal, b.Do(item => { signal.onNext(); signal.onCompleted(); }));
    var source3 = Observable.Amb(signal, c.Do(item => { signal.onNext(); signal.onCompleted(); }));
 
    return Observable.Concat(source1, source2, source3);
