    private class MyDbNull
    {
        public static MyDbNull Value = new MyDbNull();
        public override bool Equals(object obj)
        {
            return false;
        }
        public override int GetHashCode()
        {
            return 0;
        }
    }
    table.Rows.Add(2, MyDbNull.Value);
    table.Rows.Add(3, MyDbNull.Value);
