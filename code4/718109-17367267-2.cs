    class ExposedWebSettings : WebKit.WebSettings {
        public void g_object_set(string name, GLib.Value value) {
            SetProperty(name, value);
        }
    }
