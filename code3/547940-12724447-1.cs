public class Atom
{
    public string Name {get; protected set;}
    public string Type {get; protected set;}
}
public class SodiumAtom : Atom
{
    public SodiumAtom()
    {
        Name = "Sodium";
        Type = "Metal";
    }
}
