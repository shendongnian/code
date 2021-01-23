    public Task<int> Prop {
                get
                {
                    Func<Task<int>> f = async () => 
                    { 
                        await Task.Delay(1000); return 0; 
                    };
                    return f();
                }
            }
    
            private async void Test() 
            {
                await this.Prop;
            }
