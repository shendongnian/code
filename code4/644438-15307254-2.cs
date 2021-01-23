    public class Button
    {
        public Button()
        {
            State = new ButtonStateNormal(this);
        }
        private ButtonState _state;
        public event EventHandler<MouseEventArgs> Click;
        public ButtonState State
        {
            protected get
            {
                return _state;
            }
            set
            {
                if (_state == value)
                    return;
                if (_state != null)
                    _state.Click -= OnClick;
                if (value != null)
                    value.Click += OnClick;
                _state = value;
                
            }
        }
        protected virtual void OnClick(MouseEventArgs e)
        {
            if (Click != null)
                Click(this, e);
        }
        public void CheckForInput(){
            State.CheckForInput();
        }
    }
    public abstract class ButtonState
    {
        public abstract void CheckForInput();
        public ClickDelegate Click;
        public delegate void ClickDelegate(MouseEventArgs a);
    }
