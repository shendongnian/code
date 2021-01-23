    public class MyClass : IComparable
        {
            public int Day { get; set; }
            public int Hour { get; set; }
            public int CompareTo(object obj)
            {
                if (obj is MyClass)
                {
                    MyClass slot = (MyClass)obj;
                    if (Day < slot.Day)
                    {
                        return -1;
                    }
                    else if (Day > slot.Day)
                    {
                        return 1;
                    }
                    else
                    {
                        if (Hour < slot.Hour)
                        {
                            return -1;
                        }
                        else if (Hour > slot.Hour)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Object is not MyClass");
                }
            }
            public override int GetHashCode()
            {
                unchecked
                {
                    return Day.GetHashCode() ^ Hour.GetHashCode();
                }
            }
            public override bool Equals(object obj)
            {
                if (obj is MyClass)
                {
                    return this == (MyClass)obj;
                }
                else
                {
                    throw new ArgumentException("Object is not MyClass");
                }
            }
            public static bool operator ==(MyClass a, MyClass b)
            {
                return a.CompareTo(b) == 0;
            }
            public static bool operator !=(MyClass a, MyClass b)
            {
                return a.CompareTo(b) != 0;
            }
            public static bool operator <(MyClass a, MyClass b)
            {
                return a.CompareTo(b) < 0;
            }
            public static bool operator >(MyClass a, MyClass b)
            {
                return a.CompareTo(b) > 0;
            }
            public static bool operator <=(MyClass a, MyClass b)
            {
                return a.CompareTo(b) <= 0;
            }
            public static bool operator >=(MyClass a, MyClass b)
            {
                return a.CompareTo(b) >= 0;
            }
        }
