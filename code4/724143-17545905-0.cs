    private async void Start()
    {
        foreach (var item in all)
        {
             await item.DoWorkAsync();
        }
    }
    public class ClassA
    {
        public async Task DoWorkAsync()
        {
            bool done = false;
            while(!done)
            {
                DoStuff();
                DoMoreStuff();
                
                if(someCondition)
                {
                    done = true;
                }
                else
                {
                    await Task.Delay(1000);
                }
            }
        }
    }
