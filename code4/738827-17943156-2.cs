    using System;
    using System.Collections;
    using System.Globalization;
    using System.IO;
    class Program
    {
        static void Main()
        {
            ArrayList items = ReadFile("my.txt");
            items.Sort(FooByDateComparer.Default);
            foreach (Foo item in items)
            {
                Console.WriteLine(item.Names);
            }
        }
        class FooByDateComparer : IComparer
        {
            public static readonly FooByDateComparer Default
                = new FooByDateComparer();
            private FooByDateComparer() { }
            public int Compare(object x, object y)
            {
                return ((Foo)x).Joined.CompareTo(((Foo)y).Joined);
            }
        }
    
        static readonly char[] tab = { '\t' };
        class Foo
        {
            private string names, designation;
            private int age;
            private DateTime joined;
            public string Names { get { return names; } set { names = value; } }
            public int Age { get { return age; } set { age = value; } }
            public string Designation { get { return designation; } set { designation = value; } }
            public DateTime Joined { get { return joined; } set { joined = value; } }
        }
        static ArrayList ReadFile(string path)
        {
            ArrayList items = new ArrayList();
            using (StreamReader reader = File.OpenText(path))
            {
                // skip the first line (headers), or exit
                if (reader.ReadLine() == null) return items;
    
                // read each line
                string line;
                CultureInfo culture = CultureInfo.InvariantCulture;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(tab);
                    Foo foo = new Foo();
                    foo.Names = parts[0];
                    foo.Age = int.Parse(parts[1], culture);
                    foo.Designation = parts[2];
                    foo.Joined = DateTime.Parse(parts[3], culture);
                    items.Add(foo);
                }
            }
            return items;
        }
    }
