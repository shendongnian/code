    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    
    namespace EnumToRadioButtonPanel
    {
        public partial class MainWindow : Window
        {
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
    
            public MainWindow()
            {
                InitializeComponent();
    
                var figure = new Figure();
    
                var stackPanel = new StackPanel();
    
                Content = stackPanel;
    
                EnumToRadioButtonPanel<FigureHorizontalAnchor>(
                    stackPanel,
                    val => figure.HorizontalAnchor = val);
    
                var label = new Label();
    
                stackPanel.Children.Add(label);
    
                var button = new Button() { Content = "Display" };
    
                button.Click += (s, e) => label.Content = figure.HorizontalAnchor;
    
                stackPanel.Children.Add(button);
            }
        }
    }
