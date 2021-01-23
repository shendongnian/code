        ** snip **
        private Del _triggerMethod;
        public MenuItem(Vector2 pos,string txt,Del trig)
        {
            displayText = txt;
            _position = pos;
            _triggerMethod = trig;
        }
        ** snip **
        public void Trigger()
        {
            _triggerMethod("some message");
        }
