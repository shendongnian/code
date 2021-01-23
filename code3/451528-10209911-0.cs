        public class ListWithRTB : IList
        {
            private List<string> _contents = new List<string>();
            private int _count;
            string lastsearch = "";
            public ListWithRTB()
            {
                _count = 0;
            }
            public object rtb;
            private void UpdateRtb(string search)
            {
                lastsearch = search;
                if (rtb is RichTextBox)
                {
                    ((RichTextBox)rtb).Text = "";
                    List<string> help_contents;
                    if (search != "")
                        help_contents = _contents.Where(s => s.Contains(search)).ToList();
                    else
                        help_contents = _contents;
                    for (int i = 0; i < help_contents.Count; i++)
                    {
                        ((RichTextBox)rtb).Text += help_contents[i] + "\n";
                    }
                }
            }
            public void Filter(string search)
            {
                UpdateRtb(search);
            }
            public int Add(object value)
            {
                if (_count < _contents.Count + 1)
                {
                    _contents.Add((string)value);
                    _count++;
                    UpdateRtb(lastsearch);
                    return (_count);
                }
                else
                {
                    return -1;
                }
            }
            public void RemoveAt(int index)
            {
                _contents.RemoveAt(index);
                _count--;
                UpdateRtb(lastsearch);
            }
            public void Clear()
            {
                _contents.Clear();
                UpdateRtb(lastsearch);
                _count = 0;
            }
            public bool Contains(object value)
            {
                return _contents.Contains((string)value);
            }
            public int IndexOf(object value)
            {
                return _contents.IndexOf((string)value);
            }
            public void Insert(int index, object value)
            {
                _contents.Insert(index,(string) value);
                _count++;
            }
            public bool IsFixedSize
            {
                get
                {
                    return false;
                }
            }
            public bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }
            public void Remove(object value)
            {
                RemoveAt(IndexOf(value));
            }
            public object this[int index]
            {
                get
                {
                    return _contents[index];
                }
                set
                {
                    _contents[index] = value.ToString();
                }
            }
            
            public void CopyTo(Array array, int index)
            {
                int j = index;
                for (int i = 0; i < Count; i++)
                {
                    array.SetValue(_contents[i], j);
                    j++;
                }
            }
            public int Count
            {
                get
                {
                    return _count;
                }
            }
            public bool IsSynchronized
            {
                get
                {
                    return false;
                }
            }
            public object SyncRoot
            {
                get
                {
                    return this;
                }
            }
            
            public IEnumerator GetEnumerator()
            {
                throw new Exception("The method or operation is not implemented.");
            }
            public void PrintContents()
            {
                Console.WriteLine("List has a capacity of {0} and currently has {1} elements.", _contents.Count, _count);
                Console.Write("List contents:");
                for (int i = 0; i < Count; i++)
                {
                    Console.Write(" {0}", _contents[i]);
                }
                Console.WriteLine();
            }
        }
