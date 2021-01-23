    public static class Animation
    {
        public static void Initialize(object element)
        {
            //// initialize code
        }
        public static void Update(object element)
        {
            //// update code
        }
    }
    public class GameItem : Animatable
    {
        public GameItem(object memberToAnimate)
        {
            this.MemberToAnimate = memberToAnimate;
        }      
    }
    public class Animatable
    {
        public object MemberToAnimate { get; set; }
        public virtual void Initialize()
        {
            Animation.Initialize(this.MemberToAnimate);
        }
        public virtual void Update()
        {
            Animation.Update(this.MemberToAnimate);
        }
    }
