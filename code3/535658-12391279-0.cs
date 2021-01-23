     public class TimerUpdateService
        {
            public TimerUpdateService()
            {
                // May create here a Stopwatch to measure your time.
            }
            
            private EventHandler<EventArgs> _updater;
    
            public void Register(BaseGridViewModel baseGridViewModel)
            {
                _updater += baseGridViewModel.timerUpdate_UpDateTimers;
            }
    
            public void Unregister(BaseGridViewModel baseGridViewModel)
            {
                _updater -= baseGridViewModel.timerUpdate_UpDateTimers;
            }
            
            /// <summary>
            /// Call this method to refresh all timers on the registred 'BaseGridViewModel'.
            /// </summary>
            public void UpdateAllViewModels()
            {
                EventHandler<EventArgs> handler = _updater;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
    
        }
        
        public abstract class BaseGridViewModel
        {
            protected BaseGridViewModel()
            {
                Timer = new List<long>();
            }
    
            public void timerUpdate_UpDateTimers(object sender, EventArgs e)
            {
                Timer.Add(e.elapsed);
            }
            
            public List<long> Timer { get; set; }
            
        }
    
    
        public class CityReportViewModel : BaseGridViewModel
        {
            public IEnumerable<City.Grid> Grid { get; set; }
    
     
        }
