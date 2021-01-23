    class LookupList : List<LookupItem> {
        public void Add(int Param1, int Param2, ... sometype ParamX) {
            this.Add(new LookupItem() { Param1 = Param1, Param2 = Param2, ... ParamX = ParamX });
        }
    }
