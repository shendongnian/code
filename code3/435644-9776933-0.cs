    namespace PHOEBE
    {
        public class Analyzer
        {
            public Analyzer()
            {
                try
                {
                    DoAnalysis();
                    DoFurtherAnalysis();
                }
                catch
                {
                    //ERROR OCCURRED, ABORT ALL ANALYSIS
                    return;
                }
            }
    
        public class DoAnalysis()
        {
            Convert.ToInt32("someNumber...."); //obviously fails..
        }
    }
