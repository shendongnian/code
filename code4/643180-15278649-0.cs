    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static List<int> _viewState = new List<int>();
            static RawCollection<AwesomeInt, int> ViewState
            {
                get { return new RawCollection<AwesomeInt, int>(_viewState); }
                set { _viewState = value.RawData; }
            }
    
            static void Main(string[] args)
            {
                ViewState.Add(new AwesomeInt(1));
                ViewState.Add(new AwesomeInt(2));
                WriteViewState();
    
                ViewState[0].Val = 5;
                WriteViewState();
    
                ViewState.RemoveAt(0);
                WriteViewState();
    
                for (int i = 10; i < 15; i++)
                {
                    ViewState.Add(new AwesomeInt(i));
                }
                WriteViewState();
            }
    
            private static void WriteViewState()
            {
                for (int i = 0; i < ViewState.Count; i++)
                {
                    Console.WriteLine("The value at index {0} is {1}.", i, ViewState[i].Val);
                }
    
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    
        public class RawCollection<T, K> : Collection<T>
        {
            private List<K> _data;
    
            public RawCollection(List<K> data)
            {
                foreach (var i in data)
                {
                    var o = (T)Activator.CreateInstance(typeof(T), i);
                    var oI = o as IRawData<K>;
                    oI.RawValueChanged += (sender) =>
                    {
                        _data[this.IndexOf((T)sender)] = sender.Val;
                    };
    
                    this.Add(o);
                }
                _data = data;
            }
    
            public List<K> RawData
            {
                get
                {
                    return new List<K>(
                        this.Items.Select(
                            i => ((IRawData<K>)i).Val));
                }
            }
    
            protected override void ClearItems()
            {
                base.ClearItems();
    
                if (_data == null) { return; }
                _data.Clear();
            }
    
            protected override void InsertItem(int index, T item)
            {
                base.InsertItem(index, item);
    
                if (_data == null) { return; }
                _data.Insert(index, ((IRawData<K>)item).Val);
            }
    
            protected override void RemoveItem(int index)
            {
                base.RemoveItem(index);
    
                if (_data == null) { return; }
                _data.RemoveAt(index);
            }
    
            protected override void SetItem(int index, T item)
            {
                base.SetItem(index, item);
    
                if (_data == null) { return; }
                _data[index] = ((IRawData<K>)item).Val;
            }
        }
    
        public class AwesomeInt : IRawData<int>
        {
            public AwesomeInt(int i)
            {
                _val = i;
            }
    
            private int _val;
            public int Val
            {
                get { return _val; }
                set
                {
                    _val = value;
                    OnRawValueChanged();
                }
            }
    
            public event Action<IRawData<int>> RawValueChanged;
    
            protected virtual void OnRawValueChanged()
            {
                if (RawValueChanged != null)
                {
                    RawValueChanged(this);
                }
            }
        }
    
        public interface IRawData<T> : INotifyRawValueChanged<T>
        {
            T Val { get; set; }
        }
    
        public interface INotifyRawValueChanged<T>
        {
            event Action<IRawData<T>> RawValueChanged;
        }
    }
