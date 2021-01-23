        public class SlotData
        {
            private SlotData() { }
            public SlotData(SlotGroupBase group) 
            {
                this._group = group;
            }
            private SlotGroupBase _group;
            
            public double X1 { get; set; }
            public double X2 {get; set;}
            public double Y1 {get; set;}
            public double Y2 {get; set;}
            public double NewX1 
            {
                get
                {
                    return _group.ClientInfo._skewX + X1;
                }
            }
        }
        public class ClientInfo
        {
            public double _skewX, _skewY;
            public SlotGroup1 Group1 { get; set; }
        }
        public abstract class SlotGroupBase
        {
            private SlotGroupBase() { }
            public SlotGroupBase(ClientInfo ci) 
            {
                this._ci = ci;
            }
            private ClientInfo _ci;
            public ClientInfo ClientInfo
            {
                get
                {
                    return _ci;
                }
            }            
        }
        public class SlotGroup1 : SlotGroupBase
        {
            public SlotGroup1(ClientInfo ci):base (ci) {}
            public SlotData Slot1 { get; set; }
            public SlotData Slot2 { get; set; }
        }
        static void Main(string[] args)
        {
            ClientInfo ci = new ClientInfo();
            SlotGroup1 sg1 = new SlotGroup1(ci);
            sg1.Slot1 = new SlotData(sg1);
            sg1.Slot2 = new SlotData(sg1);
            Console.ReadLine();
        }
