    class MyRecord {
        public readonly int X;
        public readonly int Y;
        public readonly int Z;
        public MyRecord(int x, int y, int z) {
            X = x; Y = y; Z = z;
        }
        public MyRecord(MyRecord prototype, int? x = null, int? y = null, int? z = null)
            : this(x ?? prototype.X, y ?? prototype.Y, z ?? prototype.Z) { }
    }
    var rec1 = new MyRecord(1, 2, 3);
    var rec2 = new MyRecord(rec1, y: 100, z: 2);
