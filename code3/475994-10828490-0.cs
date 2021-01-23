    class MyClass : IDisposable {
        private StreamWriter _writer;
    
        MyClass() {
            _writer = File.App.....;
        }
    
        void zf_TickEvent(object sender, ZenFire.TickEventArgs e)
        {
    
            output myoutput = new output();
    
            myoutput.time = e.TimeStamp;
            myoutput.product = e.Product.ToString();
            myoutput.type = Enum.GetName(typeof(ZenFire.TickType), e.Type);
            myoutput.price = e.Price;
            myoutput.volume = e.Volume;
    
        
            _writer.Write(myoutput.time.ToString(timeFmt) + ",");
            _writer.Write(myoutput.product + "," );
            _writer.Write(myoutput.type + "," );
            _writer.Write(myoutput.price + ",");
            _writer.Write(myoutput.volume + ",");
    
        }
    
        public void Dispose() { /*see the documentation*/ }
    }
