    class Analyzer
    {
        public Analyzer()
        {
            // initialize things                
        }
        public void Analyze()
        {
            // never catch a fatal exception here
            try
            {
                AnalyzeStuff();
                ... optionally call more methods here ...
            }
            catch (NonFatalException e)
            {
                // handle non fatal exception
            }
            ... optionally call more methods (wrapped in try..catch) here ...
        }
        private void AnalyzeStuff()
        {
            // do stuff
            if (something nonfatal happens)
                throw new NonFatalException();
                
            if (something fatal happens)
                throw new FatalException();
        }
    }
