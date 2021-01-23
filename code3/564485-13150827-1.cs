    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WpfApplication1.Models;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    
    namespace WpfApplication1
    {
        public class LinesViewModel : INotifyPropertyChanged
        {
            public int Cost
            {
                get
                {
                    return Lines.Sum(x => x.X + x.Y); 
                }
            }
    
            public ObservableCollection<Line> Lines
            {
                get;
                private set;
            }
    
            public LinesViewModel()
            {
                Lines = new ObservableCollection<Line>();
                Lines.Add(new Line()
                {
                    Name = "Line1",
                    X = 0,
                    Y = 1
                });
                Lines.Add(new Line()
                {
                    Name = "Line2",
                    X = 1,
                    Y = 1
                });
                Lines.Add(new Line()
                {
                    Name = "Line3",
                    X = 2,
                    Y = 2
                });
    
                foreach(Line line in Lines)
                {
                    line.XChanged += new EventHandler(lineChanged);
                    line.YChanged += new EventHandler(lineChanged);
                }
    
                Lines.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Lines_CollectionChanged);
            }
    
            private void Lines_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                if (e.NewItems != null)
                {
                    foreach (Line line in e.NewItems)
                    {
                        line.XChanged += new EventHandler(lineChanged);
                        line.YChanged += new EventHandler(lineChanged);
                    }
                }
                if (e.OldItems != null)
                {
                    foreach (Line line in e.OldItems)
                    {
                        line.XChanged -= new EventHandler(lineChanged);
                        line.YChanged -= new EventHandler(lineChanged);
                    }
                }
            }
    
            private void lineChanged(object sender, EventArgs e)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Cost"));
            }
    
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
        }
    }
