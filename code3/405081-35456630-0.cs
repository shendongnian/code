    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
            // Some disjoint datasets
            List<int> scores = new List<int>{3,5,2,8,4};
            List<string> names = new List<string>{"three","five","two","eight","four"};
            
            // Sequence of indices
            List<int> indices = new List<int>(System.Linq.Enumerable.Range(0, scores.Count));
            
            // Sort indices, based on corresponding score
            indices.Sort(delegate(int a, int b) { return scores[a] - scores[b]; });
            
            for(int i = 0; i < indices.Count; ++i) 
            {
                // Use lookup table for indices
                int index = indices[i];
                Console.WriteLine(string.Format("Name: {0}, score: {1}", names[index], scores[index]));
            }
        }
    }
