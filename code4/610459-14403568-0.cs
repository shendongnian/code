    class MyModel
    {
        public int[] PropertyValues = new int[4];
    }
    class Main
    {
        IEnumerable<MyModel> models;
        public void MyFunc()
        {
            var models = new List<MyModel>();
            models.Add(new MyModel() { PropertyValues = new int[] { 6, 8, 7, 2 } });
            models.Add(new MyModel() { PropertyValues = new int[] { 9, 7, 6, 3 } });
            var index = 1;
            var maxValue = models.Max(m => m.PropertyValues[1]);
        }
    }
