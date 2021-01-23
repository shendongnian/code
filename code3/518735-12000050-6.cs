    class SomeObject{
        public event EventHandler SomeEvent;
        public void DoSomeStuff(){
            OnSomeEvent(EventArgs.Empty);
        )
        protected virtual void OnSomeEvent(EventArgs e){
            var handler = SomeEvent;
            if(handler != null)
                handler(this, e);
        }
    }
