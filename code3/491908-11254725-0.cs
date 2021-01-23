        public class Class1 { }
        public class Class2 : Class1 { }
        public class Class3 : Class2 { }
        private void button1_Click(object sender, EventArgs e)
        {
            Class3 c3 = new Class3();
            Console.WriteLine(TypeToString(c3.GetType()));
        }
        private string TypeToString(Type t)
        {
            if (t == null)
                return "";
            if ((t.BaseType == null) || (t.BaseType == typeof(object)))
                return t.Name;
            return TypeToString(t.BaseType) + "." + t.Name;
        }
