    using System.Windows;
    using System.Collections.Generic;
    using System.Linq;
    namespace TestWPFApp
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                var eventList = new List<Event>();
                eventList.Add(new Event() { Duration = 9, Name = "Test", ServerId = 1 });
                eventList.Add(new Event() { Duration = 8, Name = "Test", ServerId = 2 });
                eventList.Add(new Event() { Duration = 5, Name = "Test", ServerId = 3 });
                eventList.Add(new Event() { Duration = 10, Name = "Test", ServerId = 4 });
                eventList.Add(new Event() { Duration = 12, Name = "Test", ServerId = 5 });
                eventList.Add(new Event() { Duration = 15, Name = "Test", ServerId = 6 });
                eventList.Add(new Event() { Duration = 20, Name = "Test", ServerId = 7 });
                eventList.Add(new Event() { Duration = 22, Name = "Test", ServerId = 8 });
                eventList.Add(new Event() { Duration = 23, Name = "Test", ServerId = 9 });
                eventList.Add(new Event() { Duration = 25, Name = "Test", ServerId = 10 });
                eventList.Add(new Event() { Duration = 30, Name = "Test", ServerId = 11 });
    
                var ceilings = new[] { 10, 20, 30, 40, 50, 60, 70, 80 };
    
                var grouped = eventList
                    .GroupBy(item => ceilings.First(ceiling => ceiling > item.Duration))
                    .Select(g => new { Duration = "<" + g.Key, serverID  = g.Count()});
    
                dgProcessingTime.ItemsSource = grouped.ToList();
            }
        }
    
        public class Event
        {
            public int Duration { get; set; }
            public string Name { get; set; }
            public int ServerId { get; set; }
        }
    }
