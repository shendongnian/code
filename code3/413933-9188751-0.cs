    [Serializable]
        public class Person : ISerializable
        {
            private string name_value;
            private int ID_value;
    
            public Person() { }
            protected Person(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new System.ArgumentNullException("info");
                name_value = (string)info.GetValue("AltName", typeof(string));
                ID_value = (int)info.GetValue("AltID", typeof(int));
            }
    
            [SecurityPermission(SecurityAction.LinkDemand,Flags = SecurityPermissionFlag.SerializationFormatter)]
            public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                    throw new System.ArgumentNullException("info");
                info.AddValue("AltName", "XXX");
                info.AddValue("AltID", 9999);
            }
    
            public string Name
            {
                get { return name_value; }
                set { name_value = value; }
            }
    
            public int IdNumber
            {
                get { return ID_value; }
                set { ID_value = value; }
            }
        }
