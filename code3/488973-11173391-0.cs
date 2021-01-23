    void DoWork()
    {
        DoIfChecked(FooCheckBox, Foo, "Foo as Called");
        DoIfChecked(BarCheckBox, Bar, "Bar as Called");
        DoIfChecked(BazCheckBox, Baz, "Baz as Called");
    }
    void DoIfChecked(CheckBox checkBox, Action action, string message)
    {
        if (checkBox.IsChecked)
        {
            action();
            Console.WriteLine(message);
        }
    }
