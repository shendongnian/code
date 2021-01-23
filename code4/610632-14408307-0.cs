    private DispatcherTimer _checkNumberTimer = null;
    private int _myNumber = int.MinValue;
    private int _lastValue = int.MaxValue;
    public Constructor1(){
      _checkNumberTimer = new DispatcherTimer();
      _checkNumberTimer.Tick += new System.EventHandler(HandleCheckNumberTick);
      _checkNumberTimer.Interval = new TimeSpan(0, 0, 0, 2); //Timespan of 2 seconds
      _checkNumberTimer.Start();
    }
    private void HandleLoginOrderDispatcherTick(object sender, System.EventArgs e) {
      if(_myNumber == _lastValue){
        MessageBox.Show("Alert!");
        _checkNumberTimer.Stop(); //If you want
      }
      _lastValue = _myNumber;
    }
  
    private void SomeOtherCodeAffectingMyNumber(int something){
      _myNumber = something;
    }
   
