    public class Label
    {
        public string Text{get;set;}
    }
    public interface Clickable
    {
        Click();
    }
    public interface Resizable
    {
        Click();
    }
    public interface Dragable
    {
        Click();
    }
    public interface ClickableDragable : Clickable, Draggable
    {
    }
    public interface ClickableResizable : Clickable, Resizable
    {
    }
    public interface ResizableDragable : Resizable, Draggable
    {
    }
    public interface ClickableDragableResizeable : Resizable, Clickable, Draggable
    {
    }
    public class ComlexLabel : Lable, ClickableDragableResizeable
    {
        Click();
        Drag();
        Resize();
    }
