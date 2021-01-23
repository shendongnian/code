            ListView Lv_Report = new ListView();
            Lv_Report.Name = "Lv_Report";
            Lv_Report.FontSize = 14;
            Lv_Report.Height = 300;
            Lv_Report.Width = 800;
            Canvas.SetTop(Lv_Report, 10);
            Canvas.SetLeft(Lv_Report, 30);
            Cv_Scheduler.Children.Add(Lv_Report);
            Lv_Report.Background = null;
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
            myLinearGradientBrush.StartPoint = new System.Windows.Point(0, 0);
            myLinearGradientBrush.EndPoint = new System.Windows.Point(0, 1);
            Color color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#7FFFFFFF");
            myLinearGradientBrush.GradientStops.Add(new GradientStop(color, 0.02));
            color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#BFBADF69");
            myLinearGradientBrush.GradientStops.Add(new GradientStop(color, 0.19));
            color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#7FF9FCF2");
            myLinearGradientBrush.GradientStops.Add(new GradientStop(color, 1));
            color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#BEB9DE67");
            myLinearGradientBrush.GradientStops.Add(new GradientStop(color, 0.83));
            Style style = new Style(typeof(GridViewColumnHeader));
            style.Setters.Add(new Setter()
            {
                Property = GridViewColumnHeader.BackgroundProperty,
                Value = myLinearGradientBrush
            });
            var Lvitems = new List<string>();
                Lvitems.Add("WorkOrder");
                Lvitems.Add("Module1");
            GridView Gv = new GridView();
            foreach (String item in Lvitems)
            {
                DataTemplate Dtemplate = new DataTemplate();
                var markup =
                "<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" xmlns:local=\"clr-namespace:SubMeteringElectric;assembly=SubMeteringElectric\">"
                 + "<StackPanel>"
                 + "<Label Content =\"{Binding Lv_RSH_" + item + "}\" Width = \"100\" Height = \"30\" HorizontalContentAlignment = \"Center\" FontSize = \"14\" />"
                 + "</StackPanel>"
                 + "</DataTemplate>";
                byte[] byteArray = Encoding.UTF8.GetBytes(markup);
                MemoryStream stream = new MemoryStream(byteArray);
                Dtemplate = (DataTemplate)XamlReader.Load(stream);
                GridViewColumn Gvc_item = new GridViewColumn();
                Gvc_item.Header = item;
                Gvc_item.Width = 150;
                Gvc_item.CellTemplate = Dtemplate;
                Gv.Columns.Add(Gvc_item);
            }
            Gv.ColumnHeaderContainerStyle = style;
            Lv_Report.View = Gv;
        }
