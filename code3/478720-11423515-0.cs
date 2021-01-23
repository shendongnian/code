    public class JsonData
    {
        public string name { get; set; }
        public Arguments[] args { get; set; }
    }
    public class Arguments
    {
        public MouseDet mouseDet { get; set; }
    }
    public class MouseDet
    {
        public int rid { get; set; }
        public int posx { get; set; }
        public int posy { get; set; }
    }
    ...
    var posx = foo.args[0].mouseDet.posx;
