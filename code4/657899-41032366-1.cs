    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;
    using System.Windows.Controls;    
    namespace Pic_in_Datagrid
            {
                /// <summary>
                /// Interaction logic for MainWindow.xaml
                /// </summary>
                public partial class MainWindow : Window
                {
                    public StudentData stu_data { get; set; }
                    public MainWindow()
                    {
                        InitializeComponent();
                        stu_data = new StudentData();
            
                        List<StudentData> stu = new List<StudentData>();
                        stu.Add(new StudentData() { image = toBitmap(File.ReadAllBytes(@"D:\1.jpg")), stu_name = "abc" });
                        stu.Add(new StudentData() { image = toBitmap(File.ReadAllBytes(@"D:\1.jpg")), stu_name = "def" });
                        
                      
                      
                        FrameworkElementFactory factory = new FrameworkElementFactory(typeof(System.Windows.Controls.Image));
                        Binding bind = new System.Windows.Data.Binding("image");//please keep "image" name as you have set in your class data member name
                        factory.SetValue(System.Windows.Controls.Image.SourceProperty, bind);
                        DataTemplate cellTemplate = new DataTemplate() { VisualTree = factory };
                        DataGridTemplateColumn imgCol = new DataGridTemplateColumn()
                        {
                            Header = "image", //this is upto you whatever you want to keep, this will be shown on column to represent the data for helping the user...
                            CellTemplate = cellTemplate
                        };
                        dt1.Columns.Add(imgCol);
            
                        dt1.Columns.Add(new DataGridTextColumn()
                        {
                            Header = "student name",
                            Binding = new Binding("stu_name") //please keep "stu_name" as you have set in class datamember name
                        });
            
                        dt1.ItemsSource = stu;    
                    }
            
                    public static BitmapImage toBitmap(Byte[] value)
                    {
                        if (value != null && value is byte[])
                        {
                            byte[] ByteArray = value as byte[];
                            BitmapImage bmp = new BitmapImage();
                            bmp.BeginInit();
                            bmp.StreamSource = new MemoryStream(ByteArray);
                            bmp.EndInit();
                            return bmp;
                        }
                        return null;
                    }
                }
            
               public class StudentData
               {
                        public BitmapImage image { get; set; }
                        public string stu_name { get; set; }
                }
            }
