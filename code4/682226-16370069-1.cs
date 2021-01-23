    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Data;
    namespace So16368719
    {
        public partial class MainWindow
        {
            public ObservableCollection<Foo> FooItems { get; set; }
            public ListCollectionView FooItemsSource { get; set; }
            public MainWindow ()
            {
                FooItems = new ObservableCollection<Foo> {
                    new Foo("a"), new Foo("bb"), new Foo("ccc"), new Foo("d"), new Foo("ee"), new Foo("ffff")
                };
                FooItemsSource = (ListCollectionView)CollectionViewSource.GetDefaultView(FooItems);
                FooItemsSource.CustomSort = new ComparableComparer<Foo>();
                InitializeComponent();
            }
        }
        public class Foo : IComparable<Foo>
        {
            public string Name { get; set; }
            public Foo (string name)
            {
                Name = name;
            }
            public int CompareTo (Foo other)
            {
                return Name.Length - other.Name.Length;
            }
        }
        public class ComparableComparer<T> : IComparer<T>, IComparer
            where T : IComparable<T>
        {
            public int Compare (T x, T y)
            {
                return x.CompareTo(y);
            }
            public int Compare (object x, object y)
            {
                return Compare((T)x, (T)y);
            }
        }
    }
