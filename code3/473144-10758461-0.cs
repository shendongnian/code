        public void EliminateDuplicates()
        {
            //Eliminate the duplicates    
            for (int i = 0; i < results.Count; i++)
            {
                for (int j = 0; j < results.Count; j++)
                {
                    if (!(results[i].Equals(results[j])))
                    {
                        char[] rev = results[j].ToCharArray();
                        char[] forward = results[i].ToCharArray();
                        Array.Reverse(rev);
                        bool bEqual = true;
                        for( int n = 0 ; n < results[j].Length && true == bEqual ; n++ )
                        {
                            if( rev[n] != forward[n] )
                            {
                                bEqual = false;
                            }
                        }
                        if( true == bEqual)
                            results.Remove(results[j] );
                    }
                }
            }
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            Console.WriteLine("Total number of elements is : {0} ", results.Count);
        }
