    public class CircleAndBox : Circle, iBox
    {
    private Box _helper;
    public iBox Width(string width) { _helper.Width(width); return this; }
    }
