    public static class DeepCopyExt
    {
        public static T DeepCopy<T>(this T item)
            where T : ThingBase, new()
        {
            var newThing = new T();
            item.CopyInto(newThing);
            return newThing;
        }
    }
    public abstract class ThingBase
    {
        public int A { get; set; }
        public virtual void CopyInto(ThingBase target)
        {
            target.A = A;
        }
    }
    public class ThingA : ThingBase
    {
    }
    public class ThingB : ThingA
    {
        public int B { get; set; }
        public override void CopyInto(ThingBase target)
        {
            var thingB = target as ThingB;
            if(thingB == null)
            {
               throw new ArgumentException("target is not a ThingB");
            }
            thingB.B = B;
            base.CopyInto(thingB);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var b = new ThingB
            {
                A = 1,
                B = 3
            };
            //c is ThingB
            var c = b.DeepCopy();
            var b1 = new ThingA
            {
                A = 1,
            };
            //c1 is ThingA
            var c1 = b1.DeepCopy();
            Debugger.Break();
        }
    }
