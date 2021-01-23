    class Class2 {
        public Data data { get; set; }
        public Class2(ref Data maindata) {
            data = maindata;
            changeData();
            maindata = data;
            Console.WriteLine("Class2.Data = "+data.Name);
        }
        private void changeData() {
            Data test = new Data();
            test.Name = "newData";
            data = test;
        }
    }
