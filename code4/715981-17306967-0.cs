    public class Editor {
        public int Blah = 5;
    
        // Some kind of timer, with a handler like:
        void MyTimerTicker(object sender, EventArgs e)
        {
            this.Blah += 1;
        }
    }
