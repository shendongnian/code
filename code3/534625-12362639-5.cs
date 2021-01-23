    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Markup;
    using System.IO;
    using System.Xml;
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                string savedRichTextBox = XamlWriter.Save(richTextBox1);
                File.WriteAllText(@"C:\Temp\Test.xaml", savedRichTextBox);
                StringReader stringReader = new StringReader(savedRichTextBox);
                XmlReader xmlReader = XmlReader.Create(stringReader);
                RichTextBox rtbLoad = (RichTextBox)XamlReader.Load(xmlReader);
                label1.Content = rtbLoad;
            }
        }
    }
