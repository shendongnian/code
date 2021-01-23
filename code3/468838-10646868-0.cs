        class Program
        {
        private static Queue<Subtitle> _subtitles;
        private static Subtitle _activeSubtitle;
        private static TimeSpan _currentTime = new TimeSpan();
        static void Main(string[] args)
        {
            _subtitles = new Queue<Subtitle>();
            Subtitle title1 = new Subtitle()
                                  {
                                      StartTime = TimeSpan.Parse("00:00:06,000"),
                                      EndTime =  TimeSpan.Parse("00:00:07,400"),
                                      Text = "Enjoy the movie!"
                                  };
            Subtitle title2 = new Subtitle()
                                  {
                                      StartTime = TimeSpan.Parse("00:00:07,500"),
                                      EndTime =  TimeSpan.Parse("00:00:09,500"),
                                      Text = "Hi, my name is Mary"
                                  };
            Subtitle title3 = new Subtitle()
                                  {
                                      StartTime = TimeSpan.Parse("00:00:22,000"),
                                      EndTime =  TimeSpan.Parse("00:00:25,000"),
                                      Text = "Hello my name is John."
                                  };
            _subtitles.Enqueue(title1);
            _subtitles.Enqueue(title2);
            _subtitles.Enqueue(title3);
            Timer timer = new Timer(ShowSubtitles, null, 0, 100);
            while (_currentTime <= new TimeSpan(0, 0, 0, 30))
            {
                
            }
            Console.WriteLine("End");
        }
        private static void ShowSubtitles(object state)
        {
            
            if (_activeSubtitle == null && _subtitles.Count > 0)
                _activeSubtitle = _subtitles.Dequeue();
            Console.WriteLine(_currentTime);
            if (_activeSubtitle != null)
            {
                
                if (_currentTime >= _activeSubtitle.StartTime && _currentTime <= _activeSubtitle.EndTime)
                    Console.WriteLine("\t{0}", _activeSubtitle.Text);
                if (_currentTime >= _activeSubtitle.EndTime)
                    _activeSubtitle = null;
            }
            _currentTime = _currentTime.Add(new TimeSpan(0, 0, 0, 0, 100));
        }
    }
    internal class Subtitle
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Text { get; set; }
    }
