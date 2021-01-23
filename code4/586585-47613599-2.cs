        using System.Collections;
        using System.Collections.Generic;
    
        internal class SplittingEnumerable<T> : IEnumerable<IEnumerable<T>>
        {
            private readonly IEnumerable<T> backing;
            private readonly int maxSize;
            private bool hasCurrent;
            private T lastItem;
    
            public SplittingEnumerable(IEnumerable<T> backing, int maxSize)
            {
                this.backing = backing;
                this.maxSize = maxSize;
            }
    
            public IEnumerator<IEnumerable<T>> GetEnumerator()
            {
                return new Enumerator(this, this.backing.GetEnumerator());
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
    
            private class Enumerator : IEnumerator<IEnumerable<T>>
            {
                private readonly SplittingEnumerable<T> parent;
                private readonly IEnumerator<T> backingEnumerator;
                private NextEnumerable current;
    
                public Enumerator(SplittingEnumerable<T> parent, IEnumerator<T> backingEnumerator)
                {
                    this.parent = parent;
                    this.backingEnumerator = backingEnumerator;
                    this.parent.hasCurrent = this.backingEnumerator.MoveNext();
                    if (this.parent.hasCurrent)
                    {
                        this.parent.lastItem = this.backingEnumerator.Current;
                    }
                }
    
                public bool MoveNext()
                {
                    if (this.current == null)
                    {
                        this.current = new NextEnumerable(this.parent, this.backingEnumerator);
                        return true;
                    }
                    else
                    {
                        if (!this.current.IsComplete)
                        {
                            using (var enumerator = this.current.GetEnumerator())
                            {
                                while (enumerator.MoveNext())
                                {
                                }
                            }
                        }
                    }
    
                    if (!this.parent.hasCurrent)
                    {
                        return false;
                    }
    
                    this.current = new NextEnumerable(this.parent, this.backingEnumerator);
                    return true;
                }
    
                public void Reset()
                {
                    throw new System.NotImplementedException();
                }
    
                public IEnumerable<T> Current
                {
                    get { return this.current; }
                }
    
                object IEnumerator.Current
                {
                    get { return this.Current; }
                }
    
                public void Dispose()
                {
                }
            }
    
            private class NextEnumerable : IEnumerable<T>
            {
                private readonly SplittingEnumerable<T> splitter;
                private readonly IEnumerator<T> backingEnumerator;
                private int currentSize;
    
                public NextEnumerable(SplittingEnumerable<T> splitter, IEnumerator<T> backingEnumerator)
                {
                    this.splitter = splitter;
                    this.backingEnumerator = backingEnumerator;
                }
    
                public bool IsComplete { get; private set; }
    
                public IEnumerator<T> GetEnumerator()
                {
                    return new NextEnumerator(this.splitter, this, this.backingEnumerator);
                }
    
                IEnumerator IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
    
                private class NextEnumerator : IEnumerator<T>
                {
                    private readonly SplittingEnumerable<T> splitter;
                    private readonly NextEnumerable parent;
                    private readonly IEnumerator<T> enumerator;
                    private T currentItem;
    
                    public NextEnumerator(SplittingEnumerable<T> splitter, NextEnumerable parent, IEnumerator<T> enumerator)
                    {
                        this.splitter = splitter;
                        this.parent = parent;
                        this.enumerator = enumerator;
                    }
    
                    public bool MoveNext()
                    {
                        this.parent.currentSize += 1;
                        this.currentItem = this.splitter.lastItem;
                        var hasCcurent = this.splitter.hasCurrent;
    
                        this.parent.IsComplete = this.parent.currentSize > this.splitter.maxSize;
    
                        if (this.parent.IsComplete)
                        {
                            return false;
                        }
    
                        if (hasCcurent)
                        {
                            var result = this.enumerator.MoveNext();
    
                            this.splitter.lastItem = this.enumerator.Current;
                            this.splitter.hasCurrent = result;
                        }
    
                        return hasCcurent;
                    }
    
                    public void Reset()
                    {
                        throw new System.NotImplementedException();
                    }
    
                    public T Current
                    {
                        get { return this.currentItem; }
                    }
    
                    object IEnumerator.Current
                    {
                        get { return this.Current; }
                    }
    
                    public void Dispose()
                    {
                    }
                }
            }
        }
