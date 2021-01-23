    public abstract class UIElement
    {
        //constructor
        protected UIElement();
        //draw element
        public abstract void Draw(int mouseX, int mouseY);
        //checks if the element is pointed at by mouse
        public abstract bool IsPointed(int mouseX, int mouseY);
        //defines what happens when clicked
        public abstract void Click(int mouseX, int mouseY);
    }
