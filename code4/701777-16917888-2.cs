    public async Task Update()
    {
        while (true)
        {
            ShootAtPlayer();
            await Wait(30);
        }
    }
    
    private async Task Wait(int x)
    {
        await fiber.Wait(removeScript ? -1 : x);
    }
