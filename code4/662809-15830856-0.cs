    using System;
    namespace ClassLibrary
    {
        internal enum TargetContainerType
        {
            Endpoint,
            Group,
            User,
            UserGroup
        }
        public class TargetContainerDto
        {
            internal TargetContainerType Type
            {
                get;
                set;
            }
            public void Print()
            {
                Console.WriteLine(Type);
            }
        }
    }
