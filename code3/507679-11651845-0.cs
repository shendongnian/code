    class PageLoc
    {
        public int Header { get; set; }
        public int Body { get; set; }
        public int Footer { get; set; }
        void MoveAll(int distance) {
            Header += distance;
            Body += distance;
            Footer += distance;
        }
    }
