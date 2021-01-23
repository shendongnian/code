    void EnumToRadioButtonPanel<T>(Panel panel, Action<T> proc)
    {
        Array.ForEach((int[])Enum.GetValues(typeof(T)),
            val =>
            {
                var button = new RadioButton() { Content = Enum.GetName(typeof(T), val) };
                button.Click += (s, e) => proc((T)Enum.ToObject(typeof(T),val));
                panel.Children.Add(button);
            });
    }
