    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Management;
    using System.Collections.ObjectModel;
    
    namespace PrinterDisplay
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
    
            public ObservableCollection<SystemPrinter> Printers
            {
                get { return (ObservableCollection<SystemPrinter>)GetValue(PrintersProperty); }
                set { SetValue(PrintersProperty, value); }
            }
            public static readonly DependencyProperty PrintersProperty = DependencyProperty.Register("Printers", typeof(ObservableCollection<SystemPrinter>), typeof(MainWindow), new UIPropertyMetadata(null));
    
            public MainWindow()
            {
                InitializeComponent();
    
                Printers = new ObservableCollection<SystemPrinter>();
                ManagementObjectSearcher printers = new ManagementObjectSearcher("Select Name, PortName from Win32_Printer");
                foreach (ManagementObject printer in printers.Get())
                    this.Printers.Add(new SystemPrinter()
                    {
                        Name = (string)printer.GetPropertyValue("Name"),
                        Port = (string)printer.GetPropertyValue("PortName"),
                    });
            }
        }
    
        public class SystemPrinter
        {
            public string Name { get; set; }
            public string Port { get; set; }
        }
    }
