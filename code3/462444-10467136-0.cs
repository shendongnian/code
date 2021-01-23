    private StringBuilder text = new StringBuilder();
        protected override void Update(GameTime game_time)
        {
            text.Remove(0, text.Length);
            text.Append((float)GC.GetTotalMemory(true) / (1024 * 1024)));
            //base.Update(game_time);
        }
