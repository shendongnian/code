            public class Person {
                public virtual int Number { get; set; }
                public virtual string LastName { get; set; }
                public virtual string OtherNames { get; set; }
            }
            public class Member : Person {
                public override int Number { get; set; }
                public override string LastName { get; set; }
                public override string OtherNames { get; set; }
            }
