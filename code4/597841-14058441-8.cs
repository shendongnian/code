        public class ListEventArgs : EventArgs
        {
            public List<string> Data { get; set; }
            public ListEventArgs(List<string> data)
            {
                Data = data;
            }
        }
