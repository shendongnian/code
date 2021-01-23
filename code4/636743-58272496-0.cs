c#
using System;
class Test
{
    static void Main()
    {
        float a = .1f + .2f;
        float b = .3f;
        Console.WriteLine(a == b);                 // true
        Console.WriteLine(a.Equals(b));            // true
        Console.WriteLine(.1f + .2f == .3f);       // true
        Console.WriteLine((1f + .2f).Equals(.3f)); //false
        Console.WriteLine(.1d + .2d == .3d);       //false
        Console.WriteLine((1d + .2d).Equals(.3d)); //false
    }
}
