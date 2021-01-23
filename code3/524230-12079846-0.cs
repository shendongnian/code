    using System.ComponentModel;
    using System;
    using System.Windows.Forms;
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class DisplayModeAttribute : Attribute
    {
        private readonly string mode;
        public DisplayModeAttribute(string mode)
        {
            this.mode = mode ?? "";
        }
        public override bool Match(object obj)
        {
            var other = obj as DisplayModeAttribute;
            if (other == null) return false;
            if (other.mode == mode) return true;
            // allow for a comma-separated match, in either direction
            if (mode.IndexOf(',') >= 0)
            {
                string[] tokens = mode.Split(',');
                if (Array.IndexOf(tokens, other.mode) >= 0) return true;
            }
            else if (other.mode.IndexOf(',') >= 0)
            {
                string[] tokens = other.mode.Split(',');
                if (Array.IndexOf(tokens, mode) >= 0) return true;
            }
            return false;
        }
    }
    public class AppSettings
    {
        [DisplayMode("A"), CategoryAttribute("Document Settings"), DefaultValueAttribute(true)]
        public bool SaveOnClose { get; set; }
        [DisplayMode("A,B")]
        [CategoryAttribute("Global Settings"), ReadOnlyAttribute(true), DefaultValueAttribute("Welcome to AppDev!")]
        public string GreetingText { get; set; }
        [DisplayMode("B"), BrowsableAttribute(true), DescriptionAttribute("The rate in milliseconds that the text will repeat."), CategoryAttribute("Global Settings"), DefaultValueAttribute(10)]
        public int MaxRepeatRate { get; set; }
        [BrowsableAttribute(true), CategoryAttribute("Global Settings"), DefaultValueAttribute(4)]
        public int ItemsInMRUList { get; set; }
        [BrowsableAttribute(true), DefaultValueAttribute(false)]
        public bool SettingsChanged { get; set; }
        [BrowsableAttribute(true), CategoryAttribute("Version"), DefaultValueAttribute("1.0"), ReadOnlyAttribute(true)]
        public string AppVersion { get; set; }
    }
    static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var form = new Form())
            using (var grid = new PropertyGrid())
            {
                grid.Dock = DockStyle.Fill;
                grid.SelectedObject = new AppSettings();
                grid.BrowsableAttributes = new AttributeCollection(
                    new DisplayModeAttribute("A"));
                form.Controls.Add(grid);
                form.ShowDialog();
                grid.BrowsableAttributes = new AttributeCollection(
                    new DisplayModeAttribute("B"));
                form.ShowDialog();
            }
        }
    }
