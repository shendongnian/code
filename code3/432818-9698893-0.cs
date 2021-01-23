    public int[] RecNo {
        get {
            if (recno == null) { GetRecNo(); }
            return recno;
        }
    }
