    public class RenderHandler : IObserver<IEvent<Rendering>>
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly IList<IEvent<Rendering>> _renderBuffer = new List<IEvent<Rendering>>();
        private Game _game;
        public RenderHandler(Game game)
        {
            _game = game;
            this._spriteBatch = new SpriteBatch(game.GraphicsDevice);
        }
        public void OnNext(IEvent<Rendering> value)
        {
            _renderBuffer.Add(value);
            if ((value.EventArgs.When.ElapsedGameTime >= _game.TargetElapsedTime))
            {
                OnRender(_renderBuffer);
                _renderBuffer.Clear();
            }
        }
        private void OnRender(IEnumerable<IEvent<Rendering>> obj)
        {
            var renderBatches = obj.GroupBy(x => x.EventArgs.Depth)
                .OrderBy(x => x.Key).ToList(); // TODO: profile if.ToList() is needed
            foreach (var renderBatch in renderBatches)
            {
                _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
                
                foreach (var @event in renderBatch)
                {
                    OnRender(@event.EventArgs);
                }
                _spriteBatch.End();
            }
        }
        private void OnRender(Rendering draw)
        {
            _spriteBatch.Draw(
                draw.Texture,
                draw.Position,
                null,
                draw.RenderColor,
                draw.Rotation ?? 0f,
                draw.Origin ?? Vector2.Zero,
                draw.Scale,
                draw.SpriteEffects,
                0);
        }
        
