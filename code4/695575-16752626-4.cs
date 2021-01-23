    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    abstract class ImmutableList<T> : IEnumerable<T>
    {
      public static readonly ImmutableList<T> Empty = new EmptyList();
      private ImmutableList() {}  
      public abstract bool IsEmpty { get; }
      public abstract T Head { get; }
      public abstract ImmutableList<T> Tail { get; }
      public ImmutableList<T> Push(T newHead)
      {
        return new List(newHead, this);
      }  
    
      private sealed class EmptyList : ImmutableList<T>
      {
        public override bool IsEmpty { get { return true; } }
        public override T Head { get { throw new InvalidOperationException(); } }
        public override ImmutableList<T> Tail { get { throw new InvalidOperationException(); } }
      }
      private sealed class List : ImmutableList<T>
      {
        private readonly T head;
        private readonly ImmutableList<T> tail;
        public override bool IsEmpty { get { return false; } }
        public override T Head { get { return head; } }
        public override ImmutableList<T> Tail { get { return tail; } }
        public List(T head, ImmutableList<T> tail)
        {
          this.head = head;
          this.tail = tail;
        }
      }
      System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
      {
        return this.GetEnumerator();
      }
      public IEnumerator<T> GetEnumerator()
      {
        for (ImmutableList<T> current = this; !current.IsEmpty; current = current.Tail)
          yield return current.Head;
      }
    }  
     
    class Program
    {
      // Preconditions:
      // * items is a sequence of non-negative monotone increasing integers
      // * n is the number of items to be in the subsequence
      // * sum is the desired sum of that subsequence.
      // Result:
      // A sequence of subsequences of the original sequence where each 
      // subsequence has n items and the given sum.
      static IEnumerable<ImmutableList<int>> M(ImmutableList<int> items, int sum, int n)
      {
        // Let's start by taking some easy outs. If the sum is negative
        // then there is no solution. If the number of items in the
        // subsequence is negative then there is no solution.
    
        if (sum < 0 || n < 0)
          yield break;
    
        // If the number of items in the subsequence is zero then
        // the only possible solution is if the sum is zero.
        if (n == 0)
        {
          if (sum == 0)
            yield return ImmutableList<int>.Empty;
          yield break;
        }
    
        // If the number of items is less than the required number of 
        // items, there is no solution.
    
        if (items.Count() < n)
          yield break;
    
        // We have at least n items in the sequence, and
        // and n is greater than zero.
        int first = items.Head;
    
        // We need n items from a monotone increasing subsequence
        // that have a particular sum. We might already be too 
        // large to meet that requirement:
     
        if (n * first > sum)
          yield break;
    
        // There might be some solutions that involve the first element.
        // Find them all.
    
        foreach(var subsequence in M(items.Tail, sum - first, n - 1))
          yield return subsequence.Push(first);      
    
        // And there might be some solutions that do not involve the first element.
        // Find them all.
        foreach(var subsequence in M(items.Tail, sum, n))
          yield return subsequence;
      }
      static void Main()
      {
        ImmutableList<int> x = ImmutableList<int>.Empty.Push(5).
                               Push(4).Push(3).Push(2).Push(1).Push(0);
        for (int i = 0; i <= 15; ++i)
          foreach(var seq in M(x, i, 4))
            Console.WriteLine("({0}) SUM {1}", string.Join(",", seq), i);
      }
    }       
