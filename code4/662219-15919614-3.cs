    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Xml.Linq;
    using System.Xml;
    using System.ComponentModel;
    using System.Globalization;
    
    namespace TreeViewSortingWithXmlDataProvider
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                XmlDocument xmlDoc = new XmlDocument();
                XDocument xDoc = new XDocument(
                                        new XDeclaration("1.0", "utf-8", "yes"),
                                        new XComment("Test of sorting"),
                                        new XElement("Header", new XAttribute("Name", "Header")));
    
                XElement groupElementA = new XElement("Group", new XAttribute("Name", "A"));
                XElement groupElementB = new XElement("Group", new XAttribute("Name", "B"));
    
                XElement item1 = new XElement("Item", new XAttribute("Name", "TestItem1"), new XAttribute("sortPos", "3"));
                XElement item2 = new XElement("Item", new XAttribute("Name", "TestItem0"), new XAttribute("sortPos", "2"));
                XElement item3 = new XElement("Item", new XAttribute("Name", "TestItem3"), new XAttribute("sortPos", "1"));
    
                XElement item4 = new XElement("Item", new XAttribute("Name", "TestItem4"), new XAttribute("sortPos", "0"));
                XElement item5 = new XElement("Item", new XAttribute("Name", "TestItem5"), new XAttribute("sortPos", "2"));
    
                groupElementA.Add(item1);
                groupElementA.Add(item2);
                groupElementA.Add(item3);
    
                groupElementB.Add(item4);
                groupElementB.Add(item5);
    
                xDoc.Element("Header").Add(groupElementA);
                xDoc.Element("Header").Add(groupElementB);
    
                xmlDoc.LoadXml(xDoc.ToString());
                XmlDataProvider provider = new XmlDataProvider() { Document = xmlDoc, XPath = "Header" };
                this.myTreeView.SetBinding(TreeView.ItemsSourceProperty, new Binding() { Source = provider });
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                this.myTreeView.Items.SortDescriptions.Clear();
                this.myTreeView.Items.SortDescriptions.Add(new SortDescription("@Name", ListSortDirection.Descending));
            }
        }
    
        public class MyConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                System.Collections.IList collection = value as System.Collections.IList;
                ListCollectionView view = new ListCollectionView(collection);
                SortDescription sort = new SortDescription(parameter.ToString(), ListSortDirection.Ascending);
                view.SortDescriptions.Add(sort);
    
                return view;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return null;
            }
        }
    }
