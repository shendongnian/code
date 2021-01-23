[DataContract]
class Base
{
    [DataMember]
    public int X { get; set; }
} 
[DataContract]
class Derived : Base
{
    [DataMember]
    private new int X
    {
        get => base.X;
        set => base.X = value;
    }
}
The ```DataContractSerializer``` reads the property through reflection, so it does not really care about the property being private, but having the property in its original location private, prevents using it from code (as intended).
