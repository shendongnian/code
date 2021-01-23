    class Program {
        static void Main(string[] args) {
            blinkText t = new blinkText("TestTestTest", 500); //new blinkText object
            t.start(); //start blinking
            Thread.Sleep(5000); //Do your work here
            t.stop(); //When your work is finished, call stop() to stop the blinking text blinking
            Console.ReadKey();
        }
    }
    public class blinkText {
        public blinkText(string text, int delay) {
            this.text = text;
            this.delay = delay;
            this.startLine = Console.CursorTop; //line number of the begin of the text
            this.startColumn = Console.CursorLeft; //column number of the begin of the text
            Console.Write(this.text);
            visible = true;
        }
        public string text;
        public int delay;
        int startLine;
        int startColumn;
        bool visible;
        Timer t;
        public void start() {
            t = new Timer(delegate { //Timer to do work async
                int oldCursorX = Console.CursorLeft; //Save cursor position
                int oldCursorY = Console.CursorTop;  //to restore them later
                Console.CursorLeft = startLine; //change cursor position to
                Console.CursorTop = startColumn; //the begin of the text
                visible = !visible;
                if (visible) {
                    Console.Write(text); //write text (overwrites the whitespaces)
                } else {
                    ConsoleColor oldColor = Console.ForegroundColor; //change fore color to back color
                    Console.ForegroundColor = Console.BackgroundColor; //(makes text invisible)
                    Console.Write(text); //write invisible text(overwrites visible text)
                    Console.ForegroundColor = oldColor; //restore the old color(makes text visible)
                }
                Console.CursorLeft = oldCursorX; //restore cursor position
                Console.CursorTop = oldCursorY;
            });
            t.Change(0, this.delay); //start timer
        }
        public void stop() {
            t.Change(0, -1); //stop timer
            int oldCursorX = Console.CursorLeft;
            int oldCursorY = Console.CursorTop;
            Console.CursorLeft = startLine;
            Console.CursorTop = startColumn;
            Console.Write(text); //display text visible
            Console.CursorLeft = oldCursorX;
            Console.CursorTop = oldCursorY;
            visible = true;
        }
    }
