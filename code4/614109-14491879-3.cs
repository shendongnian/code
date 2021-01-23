    using ProtoBuf;
    using System.Collections.Generic;
    using System.IO;
    public class Class1
    {
        public Class1()
        {
            using (FileStream fs = new FileStream("c:\\formatADataFile.dat",
                   FileMode.Open, FileAccess.Read))
            {
                A oldA = Serializer.Deserialize<A>(fs);
                B newB = oldA.ConvertedToB;
            }
        }
    }
    [ProtoContract()]
    public class B
    {
        public B(A a)
        {
            //Property now has a different name
            this.Enabled = a.IsActive; 
            //Property requires math for correctness
            this.TimeInMilliseconds = a.TimeInSeconds * 1000; 
            this.Name = a.Name;
            //Reference objects change, too
            this.CustomObject2 = new CustomObject2(a.CustomObj); 
            this.ComplexThings = new List<ComplexThings>();
            this.ComplexThings.AddRange(a.ComplexThings);
            //...
        }
        public B() { }
        //[DataMember]
        [ProtoMember(1)]
        public bool Enabled { get; set; }
        //[DataMember]
        public int Version
        {
            get { return 2; }
            private set { }
        }
        [ProtoMember(2)]
        public double TimeInMilliseconds { get; set; }
        [ProtoMember(3)]
        public string Name { get; set; }
        [ProtoMember(4)]
        public CustomObject2 CustomObject { get; set; } //Also a DataContract
        [ProtoMember(5)]
        public List<ComplexThing> ComplexThings { get; set; } //Also a DataContract
        ///...
    }
    [ProtoContract()]
    public class CustomObject2
    {
        public CustomObject2()
        {
            Something = string.Empty;
        }
        [ProtoMember(1)]
        public string Something { get; set; }
    }
    [ProtoContract()]
    public class A
    {
        public A()
        {
            mBConvert = new B();
        }
        [ProtoMember(1)]
        public bool IsActive { get; set; }
        [ProtoMember(2)]
        public int VersionNumber
        {
            get { return 1; }
            private set { }
        }
        [ProtoBeforeSerialization()]
        private void NoMoreSavesForA()
        {
            throw new System.InvalidOperationException("Do Not Save A");
        }
        private B mBConvert;
        [ProtoAfterDeserialization()]
        private void TranslateToB()
        {
            mBConvert = new B(this);
        }
        public B ConvertedToB
        {
            get
            {
                return mBConvert;
            }
        }
        [ProtoMember(3)]
        public int TimeInSeconds { get; set; }
        [ProtoMember(4)]
        public string Name { get; set; }
        [ProtoMember(5)]
        public CustomObject CustomObj { get; set; } //Also a DataContract
        [ProtoMember(6)]
        public List<ComplexThing> ComplexThings { get; set; } //Also a DataContract
        //...
    }
    [ProtoContract()]
    public class CustomObject
    {
        public CustomObject()
        {
        }
        [ProtoMember(1)]
        public int Something { get; set; }
    }
    [ProtoContract()]
    public class ComplexThing
    {
        public ComplexThing()
        {
        }
        [ProtoMember(1)]
        public int SomeOtherThing { get; set; }
    }
