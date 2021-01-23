    public partial class Xservt : Window
    {
    
        internal class TimerStateObjClass
        {
            public int SomeValue;
            public System.Threading.Timer SqlUpdateFromTwitterTimerReference;
            public bool TimerCanceled;
        }
    
        TimerStateObjClass stateObj;  //THIS IS THE ORIGINAL STATE OBJ
        internal void SomeMethod()
        {
            stateObj = new TimerStateObjClass();
            stateObj.TimerCanceled = false;
            stateObj.SomeValue = 100;
            System.Threading.TimerCallback timerDelegate = new System.Threading.TimerCallback(twit.hometimelineclass._sqlUpdateFromTwitterWorker_DoWork);
    
            var sqlUpdateFromTwitterTimer = new Timer(timerDelegate, stateObj, 0, 20000);
            stateObj.SqlUpdateFromTwitterTimerReference = sqlUpdateFromTwitterTimer;
        }
    
        //action to perform which disposes the timer
        private void btnconfigOpenConfig(object sender, RoutedEventArgs e)
        {
            //HERE WE CAN GET AT THE ORIGINAL STATE OBJ
            stateObj.TimerCanceled = true;
        }
    }
        //Actions the timer is calling, in another class
        internal static void _sqlUpdateFromTwitterWorker_DoWork(object StateObj)
        {
            Xservt.TimerStateObjClass state = (Xservt.TimerStateObjClass)StateObj;
    
            if (state.TimerCanceled)
            {
                state.SqlUpdateFromTwitterTimerReference.Dispose();
            }
    
            //some work
        }
    
