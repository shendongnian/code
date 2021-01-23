    public abstract class SomeEntity
    {
        /* members omitted for brevity */
        IList _eventHandlers = new List<object>();
        public void AddHandlerWithSubscription<T, TType>(IObservable<T> observable, 
                                                    Func<TType, Action<T>> handlerSelector)
                                                        where TType: SomeEntity
        {
          var handler = handlerSelector((TType)this);
          observable.Subscribe(observable, eventHandler);
        }
        public void AddHandler<T>(Action<T> eventHandler) where T : class
        {
            var subj = Observer.Create(eventHandler);            
            AddHandler(subj);
        }
        protected void AddHandler<T>(IObserver<T> handler) where T : class
        {
            if (handler == null)
                return;
            _eventHandlers.Add(handler);
        }
        /// <summary>
        /// Changes internal rendering state for the object, then raises the Render event 
        ///  informing subscribers that this object needs rendering)
        /// </summary>
        /// <param name="rendering">Rendering parameters</param>
        protected virtual void OnRender(PreRendering rendering)
        {
            var renderArgs = new Rendering
                                 {
                                     SpriteEffects = this.SpriteEffects = rendering.SpriteEffects,
                                     Rotation = this.Rotation = rendering.Rotation.GetValueOrDefault(this.Rotation),
                                     RenderTransform = this.Transform = rendering.RenderTransform.GetValueOrDefault(this.Transform),
                                     Depth = this.DrawOrder = rendering.Depth,
                                     RenderColor = this.Color = rendering.RenderColor,
                                     Position = this.Position,
                                     Texture = this.Texture,
                                     Scale = this.Scale, 
                                     Size = this.DrawSize,
                                     Origin = this.TextureCenter, 
                                     When = rendering.When
                                 };
            RaiseEvent(Event.Create(this, renderArgs));
        }
        /// <summary>
        /// Extracts a render data object from the internal state of the object
        /// </summary>
        /// <returns>Parameter object representing current internal state pertaining to rendering</returns>
        private PreRendering GetRenderData()
        {
            var args = new PreRendering
                           {
                               Origin = this.TextureCenter,
                               Rotation = this.Rotation,
                               RenderTransform = this.Transform,
                               SpriteEffects = this.SpriteEffects,
                               RenderColor = Color.White,
                               Depth = this.DrawOrder,
                               Size = this.DrawSize,
                               Scale = this.Scale
                           };
            return args;
        }
