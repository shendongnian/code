    public Task<int> Prop {
                    get
                    {
                        return Task.Delay(1000).ContinueWith((task)=>0);
                    }
                }
