    Items = new ObservableCollection<WidgetCollectionItem>();
                foreach (XElement wid in document.Root.Elements("widget"))
                {
                    WidgetCollectionItem widget = new WidgetCollectionItem();
                    widget.nombreWidget = wid.Attribute("caption").Value;
                    foreach (XElement service in wid.Elements("service"))
                    {
                        ServiciosWidgetCollectionItem ser = new ServiciosWidgetCollectionItem();
                        widget.ItemsSer = new ObservableCollection<ServiciosWidgetCollectionItem>();
                        ser.nombreServicio = service.Attribute("caption").Value;
                        ser.valor = service.Element("xvalue").Value;
                        ser.color = service.Element("xcolor").Value;
                        ser.alerta = service.Element("xalert") != null ? service.Element("xalert").Value : null;
                        widget.ItemsSer.Add(ser);
                    }
                    Items.Add(widget);
                }
    public class WidgetCollectionItem
    {
        public string nombreWidget { get; set; }
        public ObservableCollection<ServiciosWidgetCollectionItem> ItemsSer { get; set; }
    }
    public class ServiciosWidgetCollectionItem
    {
        public string nombreServicio { get; set; }
        public string valor { get; set; }
        public string color { get; set; }
        public string alerta { get; set; }
    }
