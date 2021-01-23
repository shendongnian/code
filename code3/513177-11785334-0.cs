    public class FiringComboItem
    {
       public string Text { get; set; }
       public Action OnClick { get; set; }
       override public ToString() { return Text; }
    }
