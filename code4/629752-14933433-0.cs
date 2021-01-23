    public class MapToAttribute<TFrom, TTo> : ActionFilterAttribute
    {
        private Type _typeFrom;
        private Type _typeTo;
        public int Position { get; set; }
    
        public MapToAttribute(int Position = 0)
        {
            this.Position = Position;
            this._typeFrom = typeof(TFrom);
            this._typeTo = typeof(TTo);
        }
    
        ...
    }
