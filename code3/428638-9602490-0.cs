       class Boo
        {
            public Boo()
            {
                _myDelegate = SelectJob;
                
            }
    
            Action<object> _myDelegate ;
            protected void SelectJob(object index)
            {
    
            }
        }
