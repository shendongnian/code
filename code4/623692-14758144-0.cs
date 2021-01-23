    public class Class1 : MarshalByRefObject
    {
        public static ServerClass MyServer { get; set; }
        public void setText()
        {
            ServerClass bs = MyServer;
            Label lbl = bs.Controls["label1"] as Label;
            lbl.Text = "New Text";
        }
    }
