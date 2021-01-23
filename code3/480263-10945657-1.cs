            Run r=new Run();
            r.Text = "Moo";
            var field=r.GetType().GetField("TextProperty", BindingFlags.Static | BindingFlags.NonPublic);
            var dp=field.GetValue(null) as DependencyProperty;
            BindingOperations.SetBinding(r, dp, new Binding {...});
