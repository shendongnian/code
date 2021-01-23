    class Program
    {
        [Flags]
        private enum InfoLevel:byte
        {
            Detail=0x01, Summary=0x02
        }
        private static InfoLevel logLevel = InfoLevel.Summary;
        private static void LogDetail ( string content ) 
        {
            LogInfo ( InfoLevel.Detail,content );
        }
        private static void LogSummary ( string content ) 
        {
            LogInfo ( InfoLevel.Summary , content );
        }
        private static void LogInfo ( InfoLevel level , string content ) 
        {
            if ( ( level & logLevel ) == level )
                Console.WriteLine ( content );
        }
        private static void LogInfo ( InfoLevel level , string format, 
                                      params object[] arg )
        {
            if ( ( level & logLevel ) == level )
                Console.WriteLine ( format:format, arg:arg  );
        }
        private static void LogDetail ( string format , params object [ ] arg )
        {
            LogInfo ( InfoLevel.Detail , format, arg );
        }
        private static void LogSummary ( string format , params object [ ] arg )
        {
            LogInfo ( InfoLevel.Summary , format, arg );
        }
        const string _randTestResultHeader = "\r\nRandom Array Content\r\n";
        const string _equalArrayResultHeader = "Only Length Different\r\n\r\n";
        const string _summaryTestResultsHeader = 
                                    "Size\t\tOrig Elps\tPara Elps\tComp Elps\r\n";
        const string _summaryBodyContent = 
                             "{0}\t\t{1:0.0000}\t\t{2:0.0000}\t\t{3:0.00000}\r\n";
        static void Main ( string [ ] args )
        {
            Console.SetOut(new StreamWriter(File.Create("out.txt")));
            int segLen = 0;
            int segPercent = 7;
            Console.WriteLine ( "Algorithm Test, Time results in milliseconds" );
            for ( ; segPercent < 13; segPercent ++ )
            {
                Console.WriteLine ( 
                          "Test Run with parallel Dynamic segment size at {0}%"
                           +" of Array Size (Comp always at 8%)\r\n" , segPercent);
                StringBuilder _aggrRandResults = new StringBuilder ( );
                StringBuilder _aggrEqualResults = new StringBuilder ( );
                _aggrRandResults.Append ( _randTestResultHeader );
                _aggrEqualResults.Append ( _equalArrayResultHeader );
                _aggrEqualResults.Append ( _summaryTestResultsHeader );
                _aggrRandResults.Append ( _summaryTestResultsHeader );
                for ( int i = 10 ; i < 25 ; i++ )
                {
                    int baseLen = ( int ) Math.Pow ( 2 , i );
                    segLen = ( baseLen / 100 ) * segPercent;
                    var testName = "Equal Length ";
                    var equalTestAverage = RandomRunTest ( testName , baseLen , 
                                                           baseLen, segLen );
                    testName = "Left Side Larger";
                    var lslargerTestAverage=RandomRunTest(testName,baseLen+10, 
                                                          baseLen, segLen );
                    testName = "Right Side Larger";
                    var rslargerTestAverage = RandomRunTest ( testName , baseLen ,
                                                            baseLen + 10, segLen );
                    double [ ] completelyRandomTestAvg = new double [ 3 ];
                    for ( int l = 0 ; l < completelyRandomTestAvg.Length ; l++ )
                        completelyRandomTestAvg [ l ] = ( equalTestAverage [ l ] +
                                                     lslargerTestAverage [ l ] +
                                                  rslargerTestAverage [ l ] ) / 3;
                    LogDetail ( "\r\nRandom Test Results:" );
                    LogDetail ("Original Composite Test Average: {0}" ,
                               completelyRandomTestAvg [ 0 ] );
                    LogDetail ( "Parallel Composite Test Average: {0}" ,
                                completelyRandomTestAvg [ 1 ]  );
                    _aggrRandResults.AppendFormat ( _summaryBodyContent , 
                        baseLen , 
                        completelyRandomTestAvg [ 0 ] , 
                        completelyRandomTestAvg [ 1 ] , 
                        completelyRandomTestAvg [ 2 ]);
                    testName = "Equal Len And Values";
                    var equalEqualTest = EqualTill ( testName , baseLen , 
                                                     baseLen, segLen );
                    
                    testName = "LHS Larger";
                    var equalLHSLargerTest = EqualTill ( testName , baseLen + 10 , 
                                                         baseLen, segLen );
                    
                    testName = "RHS Larger";
                    var equalRHSLargerTest = EqualTill ( testName , baseLen , 
                                                         baseLen + 10, segLen );
                    
                    double [ ] mostlyEqualTestAvg = new double [ 3 ];
                    for ( int l = 0 ; l < mostlyEqualTestAvg.Length ; l++ )
                        mostlyEqualTestAvg [ l ] = ( ( equalEqualTest [ l ] +
                                                equalLHSLargerTest [ l ] +
                                                equalRHSLargerTest [ l ] ) / 3 );
                    LogDetail( "\r\nLength Different Test Results" );
                    LogDetail( "Original Composite Test Average: {0}" , 
                               mostlyEqualTestAvg [ 0 ] );
                    LogDetail( "Parallel Composite Test Average: {0}" , 
                                mostlyEqualTestAvg [ 1 ] );
                    _aggrEqualResults.AppendFormat ( _summaryBodyContent , 
                                                     baseLen , 
                                                     mostlyEqualTestAvg [ 0 ] , 
                                                     mostlyEqualTestAvg [ 1 ] ,
                                                     mostlyEqualTestAvg [ 2 ]);
                }
                LogSummary ( _aggrRandResults.ToString() + "\r\n");
                LogSummary ( _aggrEqualResults.ToString()+ "\r\n");
            }
            Console.Out.Flush ( );
        }
        private const string _testBody = 
                      "\r\n\tOriginal:: Result:{0}, Elapsed:{1}"
                     +"\r\n\tParallel:: Result:{2}, Elapsed:{3}"
                     +"\r\n\tComposite:: Result:{4}, Elapsed:{5}";
        private const string _testHeader = 
                      "\r\nTesting {0}, Array Lengths: {1}, {2}";
        public static double[] RandomRunTest(string testName, int shortArr1Len, 
                                             int shortArr2Len, int parallelSegLen)
        {
            var shortArr1 = new ushort [ shortArr1Len ];
            var shortArr2 = new ushort [ shortArr2Len ];
            double [ ] avgTimes = new double [ 3 ];
            LogDetail ( _testHeader , testName , shortArr1Len , shortArr2Len ) ;
            for ( int i = 0 ; i < 10 ; i++ )
            {
                int arrlen1 = shortArr1.Length , arrlen2 = shortArr2.Length;
                double[] currResults = new double [ 3 ];
                FillCompareArray ( shortArr1 , shortArr1.Length );
                FillCompareArray ( shortArr2 , shortArr2.Length );
                
                var sw = new Stopwatch ( );
                
                //Force Garbage Collection 
                //to avoid having it effect 
                //the test results this way 
                //test 2 may have to garbage 
                //collect due to running second
                GC.Collect ( );
                sw.Start ( );
                int origResult = Compare ( shortArr1 , shortArr2 );
                sw.Stop ( );
                currResults[0] = sw.Elapsed.TotalMilliseconds;
                sw.Reset ( );
                
                GC.Collect ( );
                sw.Start ( );
                int parallelResult = CompareParallelOnly ( shortArr1 , shortArr2, 
                                                           parallelSegLen );
                sw.Stop ( );
                currResults [ 1 ] = sw.Elapsed.TotalMilliseconds;
                sw.Reset ( );
                GC.Collect ( );
                sw.Start ( );
                int compositeResults = CompareComposite ( shortArr1 , shortArr2 );
                sw.Stop ( );                
                currResults [ 2 ] = sw.Elapsed.TotalMilliseconds;
                
                LogDetail ( _testBody, origResult , currResults[0] , 
                            parallelResult , currResults[1], 
                            compositeResults, currResults[2]);
                for ( int l = 0 ; l < currResults.Length ; l++ )
                    avgTimes [ l ] = ( ( avgTimes[l]*i)+currResults[l]) 
                                        / ( i + 1 );
            }
            LogDetail ( "\r\nAverage Run Time Original: {0}" , avgTimes[0]);
            LogDetail ( "Average Run Time Parallel: {0}" , avgTimes[1]);
            LogDetail ( "Average Run Time Composite: {0}" , avgTimes [ 2 ] );
            return avgTimes;
        }
        public static double [ ] EqualTill ( string testName, int shortArr1Len , 
                                           int shortArr2Len, int parallelSegLen)
        {
            const string _testHeader = 
                   "\r\nTesting When Array Difference is "
                   +"Only Length({0}), Array Lengths: {1}, {2}";
            int baseLen = shortArr1Len > shortArr2Len 
                              ? shortArr2Len : shortArr1Len;
            var shortArr1 = new ushort [ shortArr1Len ];
            var shortArr2 = new ushort [ shortArr2Len ];
            double [ ] avgTimes = new double [ 3 ];
            LogDetail( _testHeader , testName , shortArr1Len , shortArr2Len );
            for ( int i = 0 ; i < 10 ; i++ )
            {
                FillCompareArray ( shortArr1 , shortArr1Len);
                Array.Copy ( shortArr1 , shortArr2, baseLen );
                double [ ] currElapsedTime = new double [ 3 ];
                var sw = new Stopwatch ( );
                //See previous explaination 
                GC.Collect ( );
                sw.Start ( );
                int origResult = Compare ( shortArr1 , shortArr2 );
                sw.Stop ( );
                currElapsedTime[0] = sw.Elapsed.TotalMilliseconds;
                sw.Reset ( );
                GC.Collect ( );
                sw.Start ( );
                int parallelResult = CompareParallelOnly ( shortArr1, shortArr2, 
                                         parallelSegLen );
                sw.Stop ( );
                currElapsedTime[1] = sw.Elapsed.TotalMilliseconds;
                sw.Reset ( );
                GC.Collect ( );
                sw.Start ( );
                var compositeResult = CompareComposite ( shortArr1 , shortArr2 );
                sw.Stop ( );
                currElapsedTime [ 2 ] = sw.Elapsed.TotalMilliseconds;
                LogDetail ( _testBody , origResult , currElapsedTime[0] , 
                    parallelResult , currElapsedTime[1], 
                    compositeResult,currElapsedTime[2]);
                
                for ( int l = 0 ; l < currElapsedTime.Length ; l++ )
                    avgTimes [ l ] = ( ( avgTimes [ l ] * i ) 
                                       + currElapsedTime[l])/(i + 1);
            }
            LogDetail ( "\r\nAverage Run Time Original: {0}" , avgTimes [ 0 ] );
            LogDetail ( "Average Run Time Parallel: {0}" , avgTimes [ 1 ] );
            LogDetail ( "Average Run Time Composite: {0}" , avgTimes [ 2 ] );
            return avgTimes;
        }
        static Random rand = new Random ( );
        public static void FillCompareArray ( ushort[] compareArray, int length ) 
        {
            var retVals = new byte[length];
            ( rand ).NextBytes ( retVals );
            Array.Copy ( retVals , compareArray , length);
        }
        public static int CompareParallelOnly ( ushort [ ] x , ushort[] y, 
                                                int segLen ) 
        {
           int len = x.Length<y.Length ? x.Length:y.Length;
           int compareArrLen = (len/segLen)+1;
           int[] compareArr = new int [ compareArrLen ];
           Parallel.For ( 0 , compareArrLen , 
               new Action<int , ParallelLoopState> ( ( i , state ) =>
           {
               if ( state.LowestBreakIteration.HasValue 
                        && state.LowestBreakIteration.Value < i )
                   return;
               int segEnd = ( i + 1 ) * segLen;
               int k = len<segEnd?len:segEnd;
               for ( int j = i * segLen ; j < k ; j++ )
                   if ( x [ j ] != y [ j ] )
                   {
                       compareArr [ i ] = ( x [ j ].CompareTo ( y [ j ] ) );
                       state.Break ( );
                       return;
                   }
           } ) );
           int r=compareArrLen-1;
           while ( r >= 0 ) 
           {
               if ( compareArr [ r ] != 0 )
                   return compareArr [ r ];
               r--;
           }
           return x.Length.CompareTo ( y.Length );
        }
        public static int Compare ( ushort [ ] x , ushort [ ] y )
        {
            int pos = 0;
            int len = Math.Min ( x.Length , y.Length );
            while ( pos < len && x [ pos ] == y [ pos ] )
                pos++;
            return pos < len ?
                x [ pos ].CompareTo ( y [ pos ] ) :
                x.Length.CompareTo ( y.Length );
        }
        public static int CompareParallel ( ushort[] x, ushort[] y, int len, 
                                            int segLen )
        {
            int compareArrLen = ( len / segLen ) + 1;
            int [ ] compareArr = new int [ compareArrLen ];
            Parallel.For ( 0 , compareArrLen , 
                new Action<int , ParallelLoopState> ( ( i , state ) =>
            {
                if ( state.LowestBreakIteration.HasValue 
                     && state.LowestBreakIteration.Value < i )
                    return;
                int segEnd = ( i + 1 ) * segLen;
                int k = len < segEnd ? len : segEnd;
                for ( int j = i * segLen ; j < k ; j++ )
                    if ( x [ j ] != y [ j ] )
                    {
                        compareArr [ i ] = ( x [ j ].CompareTo ( y [ j ] ) );
                        state.Break ( );
                        return;
                    }
            } ) );
            int r = compareArrLen - 1;
            while ( r >= 0 )
            {
                if ( compareArr [ r ] != 0 )
                    return compareArr [ r ];
                r--;
            }
            return x.Length.CompareTo ( y.Length );
        }
        public static int CompareSequential(ushort [ ] x , ushort [ ] y, int len)
        {
            int pos = 0;
            while ( pos < len && x [ pos ] == y [ pos ] )
                pos++;
            return pos < len ?
                x [ pos ].CompareTo ( y [ pos ] ) :
                x.Length.CompareTo ( y.Length );
        }
        public static int CompareComposite ( ushort [ ] x , ushort [ ] y ) 
        {
            const int cutOff = 4096;
            int len = x.Length < y.Length ? x.Length : y.Length;
            
            if ( len > cutOff && x [ len - 1 ] == y [ len - 1 ]
                     && x [ len/2 ] == y [ len/2 ] )
                return CompareParallel ( x , y , len , (len / 100)*8 );
            
            return CompareSequential ( x , y, len );
        }
    }
