    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
    
            PropertyGrid grid;
            using (var form = new Form
            {
                Controls = { (grid = new PropertyGrid { Dock = DockStyle.Fill}) }
            })
            {
                grid.SelectedObject = new Magic {ShowY = false};
                Application.Run(form);
            }
        }
    }
    
    [TypeConverter(typeof(MagicTypeConverter))]
    public class Magic
    {
        public Magic()
        {
            ShowX = ShowY = ShowZ = true;
        }
    
        public int A { get; set; }
        public bool B { get; set; }
        public string C { get; set; }
        public int X { get; set; }
        public bool Y { get; set; }
        public string Z { get; set; }
    
        [Browsable(false)]
        public bool ShowX { get; set; }
        [Browsable(false)]
        public bool ShowY { get; set; }
        [Browsable(false)]
        public bool ShowZ { get; set; }
    
        private class MagicTypeConverter : ExpandableObjectConverter
        {
            public override PropertyDescriptorCollection GetProperties(
                 ITypeDescriptorContext context, object value,
                 Attribute[] attributes)
            {
                var original = base.GetProperties(context, value, attributes);
                var list = new List<PropertyDescriptor>(original.Count);
                var magic = (Magic)value;
                foreach (PropertyDescriptor prop in original)
                {
                    bool showProp = true;
                    switch (prop.Name)
                    {
                        case "X": showProp = magic.ShowX; break;
                        case "Y": showProp = magic.ShowY; break;
                        case "Z": showProp = magic.ShowZ; break;
                    }
                    if (showProp) list.Add(prop);
                }
                return new PropertyDescriptorCollection(list.ToArray());
            }
        }
    }
