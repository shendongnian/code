    public class RcvPacket{
         public abstract void On();
    }
    public class RcvPacketFoo : RcvPacket
    {
         public override void On(){} //OnFoo implemenation
    }
    public class RcvPacketBar : RcvPacket
    {
         public override void On(){} //OnBar implemenation
    }
    //....
    OnDataReceived:
        RcvPacket p = RcvPacket.ReadPacket(comport);   // Call factory method
        p.On();
