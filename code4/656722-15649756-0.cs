    class YourClass
    {
        private StreamReader _sr1;
    
        public void showSelectedFile() 
        { 
            _sr1 = new StreamReader(File.OpenRead(ReturnTxt));
            ReturnContenctRD = _sr1.ReadToEnd();
        }
    
        public void DisposeSR1() 
        { 
           if(_sr1 != null)
              _sr1.Dispose()
        }
    
    }
