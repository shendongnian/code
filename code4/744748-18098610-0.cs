            ClassA clsA = new ClassA();
            if (clsA.MyProperty == null)
                MessageBox.Show("IsNull");
            clsA.MyProperty = new Func<string, bool>(x => x.Equals("1"));
            MessageBox.Show(clsA.MyProperty == null ? "IsNull" : "IsNotNull");
