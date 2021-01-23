    using System;
    using System.IO;
    using System.Diagnostics;
    /*
    This code demonstrates a cloning pattern that you can use for class hierarchies.
    The abstract base class specifies an abstract Clone() method which must be implemented by all derived classes.
    Every class except the abstract base class must have a protected copy constructor. 
    This protected copy constructor will:
    (1) call the base class' copy constructor, and 
    (2) set any new fields introduced in the derived class.
    This code also demonstrates an implementation of Equals() and CopyFrom().
    */
    namespace CloningPattern
    {
        static class Program
        {
            static void Main()
            {
                Derived2 test = new Derived2()
                {
                    IntValue = 1,
                    StringValue = "s",
                    DoubleValue = 2,
                    ShortValue = 3
                };
                Derived2 copy = Clone(test);
                Console.WriteLine(copy);
            }
            static Derived2 Clone(AbstractBase item)
            {
                AbstractBase abstractBase = (AbstractBase) item.Clone();
                Derived2 result = abstractBase as Derived2;
                Debug.Assert(result != null);
                return result;
            }
        }
        public abstract class AbstractBase: ICloneable
        {
            // Sample data field.
            public int IntValue { get; set; }
            // Canonical way of providing a Clone() operation
            // (except that this is abstract rather than virtual, since this class
            // is itself abstract).
            public abstract object Clone();
            // Default constructor.
            protected AbstractBase(){}
            // Copy constructor.
            protected AbstractBase(AbstractBase other)
            {
                if (other == null)
                {
                    throw new ArgumentNullException("other");
                }
                this.copyFrom(other);
            }
            // Copy from another instance over the top of an already existing instance.
            public virtual void CopyFrom(AbstractBase other)
            {
                if (other == null)
                {
                    throw new ArgumentNullException("other");
                }
                this.copyFrom(other);
            }
            // Equality check.
            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }
                if (object.ReferenceEquals(this, obj))
                {
                    return true;
                }
                if (this.GetType() != obj.GetType())
                {
                    return false;
                }
                AbstractBase other = (AbstractBase)obj;
                return (this.IntValue == other.IntValue);
            }
            // Get hash code.
            public override int GetHashCode()
            {
                return this.IntValue.GetHashCode();
            }
            // ToString() for debug purposes.
            public override string ToString()
            {
                return "IntValue = " + IntValue;
            }
            // Implement copying fields in a private non-virtual method, called from more than one place.
            private void copyFrom(AbstractBase other)  // 'other' cannot be null, so no check for nullness is made.
            {
                this.IntValue = other.IntValue;
            }
        }
        public abstract class AbstractDerived: AbstractBase
        {
            // Sample data field.
            public short ShortValue{ get; set; }
            // Default constructor.
            protected AbstractDerived(){}
            // Copy constructor.
            protected AbstractDerived(AbstractDerived other): base(other)
            {
                this.copyFrom(other);
            }
            // Copy from another instance over the top of an already existing instance.
            public override void CopyFrom(AbstractBase other)
            {
                base.CopyFrom(other);
                this.copyFrom(other as AbstractDerived);
            }
            // Comparison.
            public override bool Equals(object obj)
            {
                if (object.ReferenceEquals(this, obj))
                {
                    return true;
                }
                if (!base.Equals(obj))
                {
                    return false;
                }
                AbstractDerived other = (AbstractDerived)obj;  // This must succeed because if the types are different, base.Equals() returns false.
                return (this.IntValue == other.IntValue);
            }
            // Get hash code.
            public override int GetHashCode()
            {
                // "Standard" way of combining hash codes from subfields.
                int hash = 17;
                hash = hash * 23 + base.GetHashCode();
                hash = hash * 23 + this.ShortValue.GetHashCode();
                return hash;
            }
            // ToString() for debug purposes.
            public override string ToString()
            {
                return base.ToString() + ", ShortValue = " + ShortValue;
            }
            // This abstract class doesn't need to implement Clone() because no instances of it
            // can ever be created, on account of it being abstract and all that.
            // If you COULD, it would look like this (but you can't so this won't compile):
            // public override object Clone()
            // {
            //     return new AbstractDerived(this);
            // }
            // Implement copying fields in a private non-virtual method, called from more than one place.
            private void copyFrom(AbstractDerived other)  // Other could be null, so check for nullness.
            {
                if (other != null)
                {
                    this.ShortValue = other.ShortValue;
                }
            }
        }
        public class Derived1: AbstractDerived
        {
            // Must declare a default constructor.
            public Derived1(){}
            // Sample data field.
            public string StringValue{ get; set; }
            // Implement Clone() by simply using this class' copy constructor.
            public override object Clone()
            {
                return new Derived1(this);
            }
            // Copy from another instance over the top of an already existing instance.
            public override void CopyFrom(AbstractBase other)
            {
                base.CopyFrom(other);
                this.copyFrom(other as Derived1);
            }
            // Equality check.
            public override bool Equals(object obj)
            {
                if (object.ReferenceEquals(this, obj))
                {
                    return true;
                }
                if (!base.Equals(obj))
                {
                    return false;
                }
                Derived1 other = (Derived1)obj;  // This must succeed because if the types are different, base.Equals() returns false.
                return (this.StringValue == other.StringValue);
            }
            // Get hash code.
            public override int GetHashCode()
            {
                // "Standard" way of combining hash codes from subfields.
                int hash = 17;
                hash = hash * 23 + base.GetHashCode();
                hash = hash * 23 + this.StringValue.GetHashCode();
                return hash;
            }
            // ToString() for debug purposes.
            public override string ToString()
            {
                return base.ToString() + ", StringValue = " + StringValue;
            }
            // Protected copy constructor. Used to implement Clone().
            // Also called by a derived class' copy constructor.
            protected Derived1(Derived1 other): base(other)
            {
                this.copyFrom(other);
            }
            // Implement copying fields in a private non-virtual method, called from more than one place.
            private void copyFrom(Derived1 other)  // Other could be null, so check for nullness.
            {
                if (other != null)
                {
                    this.StringValue = other.StringValue;
                }
            }
        }
        public class Derived2: Derived1
        {
            // Must declare a default constructor.
            public Derived2(){}
            // Sample data field.
            public double DoubleValue{ get; set; }
            // Implement Clone() by simply using this class' copy constructor.
            public override object Clone()
            {
                return new Derived2(this);
            }
            // Copy from another instance over the top of an already existing instance.
            public override void CopyFrom(AbstractBase other)
            {
                base.CopyFrom(other);
                this.copyFrom(other as Derived2);
            }
            // Equality check.
            public override bool Equals(object obj)
            {
                if (object.ReferenceEquals(this, obj))
                {
                    return true;
                }
                if (!base.Equals(obj))
                {
                    return false;
                }
                Derived2 other = (Derived2)obj;  // This must succeed because if the types are different, base.Equals() returns false.
                return (this.DoubleValue == other.DoubleValue);
            }
            // Get hash code.
            public override int GetHashCode()
            {
                // "Standard" way of combining hash codes from subfields.
                int hash = 17;
                hash = hash * 23 + base.GetHashCode();
                hash = hash * 23 + this.DoubleValue.GetHashCode();
                return hash;
            }
            // ToString() for debug purposes.
            public override string ToString()
            {
                return base.ToString() + ", DoubleValue = " + DoubleValue;
            }
            // Protected copy constructor. Used to implement Clone().
            // Also called by a derived class' copy constructor.
            protected Derived2(Derived2 other): base(other)
            {
                // Canonical implementation: use ":base(other)" to copy all
                // the base fields (which recursively applies all the way to the ultimate base)
                // and then explicitly copy any of this class' fields here:
                this.copyFrom(other);
            }
            // Implement copying fields in a private non-virtual method, called from more than one place.
            private void copyFrom(Derived2 other)  // Other could be null, so check for nullness.
            {
                if (other != null)
                {
                    this.DoubleValue = other.DoubleValue;
                }
            }
        }
    }
