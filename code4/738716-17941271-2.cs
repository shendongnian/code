    class Program
    {
        static void Main(string[] args)
        {
            Properties.Settings.Default.CustomClasses = new List<CustomClass>() {
                new CustomClass(){Columns="columns1"},
                new CustomClass(){Columns="columns2"},
                new CustomClass(){Columns="columns3"},
                new CustomClass(){Columns="columns4"}
            };
            Properties.Settings.Default.Save();
        }
    }
