    namespace Alogrithms
    {
      public class ArraySearch
      {
        int[] pattern;
        Queue<int> indices = new Queue<int>();  
        int[] source;
        public ArraySearch( int[] pattern, int[] source)
        {
          this.source = source;
          this.pattern = pattern;
        }
        public int[] Pattern
        {
          get { return pattern; }
          private set { pattern = value; }
        }
        public Queue<int> Indices
        {
          get { return indices; }
          private set { indices = value; }
        }
        public int SearchForSubArray(int patternIndexPtr,int sourceIndexPtr, ref int[] source)
        {
          int end  = source.Length;
          if(patternIndexPtr >= pattern.Length || sourceIndexPtr >= end )
            return patternIndexPtr;
    
          if(pattern[patternIndexPtr] == source[sourceIndexPtr])
          {
            indices.Enqueue(sourceIndexPtr);
            return SearchForSubArray(patternIndexPtr + 1,sourceIndexPtr+1, ref source);
          }
          else
          {
            indices.Clear();
            patternIndexPtr = 0;
            return SearchForSubArray(patternIndexPtr, sourceIndexPtr + 1, ref source);
          }
        }
      }
    }
    
