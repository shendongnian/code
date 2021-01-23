    public class RcvPacket{
         public abstract void On(RcvPacketHandler eh);
    }
    public class RcvPacketFoo : RcvPacket
    {
         public override void On(RcvPacketHandler eh){eh.OnFoo();} //OnFoo implemenation
    }
    public class RcvPacketBar : RcvPacket
    {
         public override void On(RcvPacketHandler eh){eh.OnBar();} //OnBar implemenation
    }
    //Update following your comment:
    public class RcvPacketHandler
    {
    public void OnFoo(){}
    public void OnBar(){}
    //....
    OnDataReceived:
        RcvPacket p = RcvPacket.ReadPacket(comport);   // Call factory method
        p.On(this);
