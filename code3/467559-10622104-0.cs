        void _document_BeginPrint(object sender, PrintEventArgs e)
        {
            //generate some dummy strings to print
            _pageData = new List<string>()
                    {
                        "Page 1 Data",
                        "Page 2 Data",
                        "Page 3 Data",
                    };
            
            // get enumerator for dummy strings
            _pageEnumerator = _pageData.GetEnumerator();
            
            //position to first string to print (i.e. first page)
            _pageEnumerator.MoveNext();
        }
