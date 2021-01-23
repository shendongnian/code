    class CommandChangeValue<T> : Command
    {
        T _previous;
        T _new;
        Action<T> _set;
        public CommandChangeValue(T value, Action<T> setValue, T newValue)
        {
            _previous = value;
            _new = newValue;
            _set = setValue;
            setValue(_new);
        }
        public void Undo() { _set(_previous); }
        public void Redo() { _set(_new); }
    }
    // ...
    double v = 42;
    var c = new CommandChangeValue(v, d => v = d, 99);
