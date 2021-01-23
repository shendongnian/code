    // Hand-off through a bounded BufferBlock<T>
    private static BufferBlock<int> m_buffer = new BufferBlock<int>(
        new DataflowBlockOptions { BoundedCapacity = 10 });
    
    // Producer
    private static async void Producer()
    {
        while(true)
        {
            await m_buffer.SendAsync(Produce());
        }
    }
    
    // Consumer
    private static async Task Consumer()
    {
        while(true)
        {
            Process(await m_buffer.ReceiveAsync());
        }
    }
    
    // Start the Producer and Consumer
    private static async Task Run()
    {
        await Task.WhenAll(Producer(), Consumer());
    }
