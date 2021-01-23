    public override Update(GameTime gameTime)
    {
      var parallelQuery = from b in masterblocklist.AsParallel()
                                where screenRect.Contains(b.Rect) 
                                select b;
     // Process result sequence in parallel
     parallelQuery.ForAll(p => p.Update(gameTime));
    }
