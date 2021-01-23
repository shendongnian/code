    List<ClassA> all = new List<ClassA> { ... };
    private async void Start()
    {
        foreach (var item in all)
        {
             await item.DoWork();
        }
    }
    public class ClassA
    {
        public async Task DoWork()
        {
            Thread.Sleep(50000); // wait 50sec
            // Do work            
        }
    }
